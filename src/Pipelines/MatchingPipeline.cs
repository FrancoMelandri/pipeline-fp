using PipelineFp.Contexts;
using PipelineFp.Patterns;
using System.Collections.Immutable;
using TinyFp;
using TinyFp.Extensions;
using static PipelineFp.Extensions.EitherExtensions;
using static PipelineFp.Extensions.OptionExtensions;
using static TinyFp.Prelude;

namespace PipelineFp.Pipelines;

public class MatchingPipeline<TContext, TSelector> : IMatchingPipeline<TContext, TSelector>
                                                     where TContext : IPatternMatchingContext<TSelector>
{
    private readonly TContext _context;

    private MatchingPipeline(TContext context)
    {
        _context = context;
    }

    public static IMatchingPipeline<TContext, TSelector> Given(TContext context)
       => new MatchingPipeline<TContext, TSelector>(context);

    public Either<TError, TContext> Match<TError>(HashSet<IPattern<TError, TContext, TSelector>> patterns)
        => Match(patterns, _context, [], []);

    public Task<Either<TError, TContext>> Match<TError>(HashSet<IAsyncPattern<TError, TContext, TSelector>> patterns)
        => Match(patterns, _context, [], []);

    public Task<Either<TError, TContext>> Match<TError>(
        HashSet<IAsyncPattern<TError, TContext, TSelector>> patterns,
        HashSet<IAsyncOnErrorCallback<TError, TContext>> onErrorCallbacks,
        HashSet<IAsyncOnExceptionCallback<TError, TContext>> onExceptionCallbacks)
        => Match(patterns, _context, onErrorCallbacks, onExceptionCallbacks);

    public Either<TError, TContext> Match<TError>(
        HashSet<IPattern<TError, TContext, TSelector>> patterns,
        HashSet<IOnErrorCallback<TError, TContext>> onErrorCallbacks,
        HashSet<IOnExceptionCallback<TError, TContext>> onExceptionCallbacks)
        => Match(patterns, _context, onErrorCallbacks, onExceptionCallbacks);

    private static Either<TError, TContext> Match<TError>(
        HashSet<IPattern<TError, TContext, TSelector>> patterns,
        TContext context,
        HashSet<IOnErrorCallback<TError, TContext>> onErrorCallbacks,
        HashSet<IOnExceptionCallback<TError, TContext>> onExceptionCallbacks)
        => Try(() => patterns
                    .ToImmutableDictionary(pattern => pattern.Selector,
                                           match => match)
                    .Map(_ => _.GetValueOrDefault(context.Selector))
                    .Map(_ => _.ToOption()
                               .Map(_ => _.Match(context))
                               .OrElse(context))
                    .BindLeft(error => onErrorCallbacks.ToOption(_ => _.Count == 0)
                                                       .Map(_ => _.Fold(Right<TError, TContext>(context),
                                                                       (state, onError) => state.Bind(_ => onError.OnError(_, error))))
                                                       .OrElse(error)))
        .OnFail(ex => onExceptionCallbacks
                      .Fold(Right<TError, TContext>(context),
                           (state, onException) => state.Bind(_ => onException.OnException(_, ex))));

    private static Task<Either<TError, TContext>> Match<TError>(
        HashSet<IAsyncPattern<TError, TContext, TSelector>> patterns,
        TContext context,
        HashSet<IAsyncOnErrorCallback<TError, TContext>> onErrorCallbacks,
        HashSet<IAsyncOnExceptionCallback<TError, TContext>> onExceptionCallbacks)
        => TryAsync(() => patterns
                        .ToImmutableDictionary(pattern => pattern.Selector,
                                               match => match)
                        .Map(_ => _.GetValueOrDefault(context.Selector))
                        .Map(_ => _.ToOption()
                                   .MapAsync(_ => _.Match(context))
                                   .OrElse(context))
                        .BindLeftAsync(error => onErrorCallbacks.ToOption(_ => _.Count == 0)
                                                                .Map(_ => _.FoldAsync(Right<TError, TContext>(context),
                                                                                     (state, onError) => state.BindAsync(_ => onError.OnError(_, error))))
                                                                .OrElse(Left<TError, TContext>(error).AsTask())))
          .OnFail(ex => onExceptionCallbacks
                        .FoldAsync(Right<TError, TContext>(context),
                                  (state, onException) => state.BindAsync(_ => onException.OnException(_, ex))));
}