using PipelineFp.Steps;
using TinyFp;
using TinyFp.Extensions;
using static PipelineFp.Extensions.EitherExtensions;
using static TinyFp.Prelude;

namespace PipelineFp.Pipelines;

public class Pipeline<TContext> : IPipeline<TContext>
{
    private readonly TContext _context;

    private Pipeline(TContext context)
    {
        _context = context;
    }

    public static IPipeline<TContext> Given(TContext context)
        => new Pipeline<TContext>(context);

    public Either<TError, TContext> Flow<TError>(IEnumerable<IStep<TError, TContext>> steps)
        => Flow(steps, _context, [], []);

    public Task<Either<TError, TContext>> Flow<TError>(IEnumerable<IAsyncStep<TError, TContext>> steps)
        => Flow(steps, _context, [], []);

    public Task<Either<TError, TContext>> Flow<TError>(
        IEnumerable<IAsyncStep<TError, TContext>> steps,
        IEnumerable<IOnErrorAsyncStep<TError, TContext>> onFailSteps,
        IEnumerable<IOnExceptionAsyncStep<TError, TContext>> onExceptionSteps)
        => Flow(steps, _context, onFailSteps, onExceptionSteps);

    public Task<Either<TError, TContext>> Flow<TError>(
        IEnumerable<Union<Func<TContext, Task<Either<TError, TContext>>>,
                    IConditionalAsyncStep<TError, TContext>,
                    IAsyncStep<TError, TContext>>> steps)
        => Flow(steps, _context, [], []);

    public Task<Either<TError, TContext>> Flow<TError>(
       IEnumerable<Union<Func<TContext, Task<Either<TError, TContext>>>,
                   IConditionalAsyncStep<TError, TContext>,
                   IAsyncStep<TError, TContext>>> steps,
       IEnumerable<Union<Func<TContext, TError, Task<Either<TError, TContext>>>,
                         IOnErrorAsyncStep<TError, TContext>>> onFailSteps,
       IEnumerable<Union<Func<TContext, Exception, Task<Either<TError, TContext>>>,
                         IOnExceptionAsyncStep<TError, TContext>>> onExceptionSteps)
        => Flow(steps, _context, onFailSteps, onExceptionSteps);

    public Either<TError, TContext> Flow<TError>(
        IEnumerable<Union<Func<TContext, Either<TError, TContext>>,
                    IConditionalStep<TError, TContext>,
                    IStep<TError, TContext>>> steps)
        => Flow(steps, _context, [], []);

    public Either<TError, TContext> Flow<TError>(
       IEnumerable<Union<Func<TContext, Either<TError, TContext>>,
                   IConditionalStep<TError, TContext>,
                   IStep<TError, TContext>>> steps,
       IEnumerable<Union<Func<TContext, TError, Either<TError, TContext>>,
                         IOnErrorStep<TError, TContext>>> onFailSteps,
       IEnumerable<Union<Func<TContext, Exception, Either<TError, TContext>>,
                         IOnExceptionStep<TError, TContext>>> onExceptionSteps)
        => Flow(steps, _context, onFailSteps, onExceptionSteps);

    public Either<TError, TContext> Flow<TError>(
        IEnumerable<IStep<TError, TContext>> steps,
        IEnumerable<IOnErrorStep<TError, TContext>> onFailSteps,
        IEnumerable<IOnExceptionStep<TError, TContext>> onExceptionSteps)
        => Flow(steps, _context, onFailSteps, onExceptionSteps);

    private static Task<Either<TError, TContext>> Flow<TError>(
        IEnumerable<IAsyncStep<TError, TContext>> steps,
        TContext context,
        IEnumerable<IOnErrorAsyncStep<TError, TContext>> onFailSteps,
        IEnumerable<IOnExceptionAsyncStep<TError, TContext>> onExceptionSteps)
        => TryAsync(() => steps
                         .FoldAsync(Right<TError, TContext>(context),
                                   (state, step) => state.BindAsync(step.Forward))
                         .BindLeftAsync(error => onFailSteps
                                                 .ToOption(_ => !_.Any())
                                                 .Map(_ => _.FoldAsync(Right<TError, TContext>(context),
                                                                      (state, step) => state.BindAsync(_ => step.Forward(_, error))))
                                                 .OrElse(Left<TError, TContext>(error).AsTask())))
        .OnFail(ex => onExceptionSteps
                     .FoldAsync(Right<TError, TContext>(context),
                               (state, step) => state.BindAsync(_ => step.Forward(_, ex))));

    private static Task<Either<TError, TContext>> Flow<TError>(
       IEnumerable<Union<Func<TContext, Task<Either<TError, TContext>>>,
                   IConditionalAsyncStep<TError, TContext>,
                   IAsyncStep<TError, TContext>>> steps,
       TContext context,
       IEnumerable<Union<Func<TContext, TError, Task<Either<TError, TContext>>>,
                         IOnErrorAsyncStep<TError, TContext>>> onFailSteps,
       IEnumerable<Union<Func<TContext, Exception, Task<Either<TError, TContext>>>,
                         IOnExceptionAsyncStep<TError, TContext>>> onExceptionSteps)
       => TryAsync(() => steps
                        .FoldAsync(Right<TError, TContext>(context),
                                  (state, step) => state.BindAsync(_ => step.MatchAsync(__ => __(_),
                                                                                        __ => __.ToOption(__ => !__.ExecutionCondition(_))
                                                                                                .Map(__ => __.Forward(_))
                                                                                                .OrElse(state.AsTask()),
                                                                                        __ => __.Forward(_))))
                        .BindLeftAsync(error => onFailSteps
                                                .ToOption(_ => !_.Any())
                                                .Map(_ => _.FoldAsync(Right<TError, TContext>(context),
                                                           (state, step) => state.BindAsync(_ => step.MatchAsync(__ => __(_, error),
                                                                                                                 __ => __.Forward(_, error)))))
                                                .OrElse(Left<TError, TContext>(error).AsTask())))
       .OnFail(ex => onExceptionSteps
                    .FoldAsync(Right<TError, TContext>(context),
                              (state, step) => state.BindAsync(_ => step.MatchAsync(__ => __(_, ex),
                                                                                    __ => __.Forward(_, ex)))));

    private static Either<TError, TContext> Flow<TError>(
       IEnumerable<Union<Func<TContext, Either<TError, TContext>>,
                   IConditionalStep<TError, TContext>,
                   IStep<TError, TContext>>> steps,
       TContext context,
       IEnumerable<Union<Func<TContext, TError, Either<TError, TContext>>,
                         IOnErrorStep<TError, TContext>>> onFailSteps,
       IEnumerable<Union<Func<TContext, Exception, Either<TError, TContext>>,
                         IOnExceptionStep<TError, TContext>>> onExceptionSteps)
       => Try(() => steps
                        .Fold(Right<TError, TContext>(context),
                             (state, step) => state.Bind(_ => step.Match(__ => __(_),
                                                                         __ => __.ToOption(__ => !__.ExecutionCondition(_))
                                                                                 .Map(__ => __.Forward(_))
                                                                                 .OrElse(state),
                                                                         __ => __.Forward(_))))
                        .BindLeft(error => onFailSteps
                                                .ToOption(_ => !_.Any())
                                                .Map(_ => _.Fold(Right<TError, TContext>(context),
                                                           (state, step) => state.Bind(_ => step.Match(__ => __(_, error),
                                                                                                                 __ => __.Forward(_, error)))))
                                                .OrElse(Left<TError, TContext>(error))))
       .OnFail(ex => onExceptionSteps
                    .Fold(Right<TError, TContext>(context),
                              (state, step) => state.Bind(_ => step.Match(__ => __(_, ex),
                                                                                    __ => __.Forward(_, ex)))));

    private static Either<TError, TContext> Flow<TError>(
       IEnumerable<IStep<TError, TContext>> steps,
       TContext context,
       IEnumerable<IOnErrorStep<TError, TContext>> onFailSteps,
       IEnumerable<IOnExceptionStep<TError, TContext>> onExceptionSteps)
       => Try(() => steps
                   .Fold(Right<TError, TContext>(context),
                        (state, step) => state.Bind(step.Forward))
                   .BindLeft(error => onFailSteps
                                      .ToOption(_ => !_.Any())
                                      .Map(_ => _.Fold(Right<TError, TContext>(context),
                                                      (state, step) => state.Bind(_ => step.Forward(_, error))))
                                      .OrElse(error)))
       .OnFail(ex => onExceptionSteps
                    .Fold(Right<TError, TContext>(context),
                         (state, step) => state.Bind(_ => step.Forward(_, ex))));
}