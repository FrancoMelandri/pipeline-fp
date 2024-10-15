using PipelineFp.Steps;
using TinyFp;
using TinyFp.Extensions;
using static PipelineFp.Extensions.EitherExtensions;
using static TinyFp.Prelude;

namespace PipelineFp.Pipelines;

public class ConditionalPipeline<TContext> : IConditionalPipeline<TContext>
{
    private readonly TContext _context;

    private ConditionalPipeline(TContext context)
    {
        _context = context;
    }

    public static IConditionalPipeline<TContext> Given(TContext context)
        => new ConditionalPipeline<TContext>(context);

    public Either<TError, TContext> Flow<TError>(
      IEnumerable<IConditionalStep<TError, TContext>> steps)
        => Flow(steps, _context, [], []);

    public Task<Either<TError, TContext>> Flow<TError>(
       IEnumerable<IConditionalAsyncStep<TError, TContext>> steps)
        => Flow(steps, _context, [], []);

    public Task<Either<TError, TContext>> Flow<TError>(
        IEnumerable<IConditionalAsyncStep<TError, TContext>> steps,
        IEnumerable<IOnErrorAsyncStep<TError, TContext>> onFailSteps,
        IEnumerable<IOnExceptionAsyncStep<TError, TContext>> onExceptionSteps)
        => Flow(steps, _context, onFailSteps, onExceptionSteps);

    public Either<TError, TContext> Flow<TError>(
        IEnumerable<IConditionalStep<TError, TContext>> steps,
        IEnumerable<IOnErrorStep<TError, TContext>> onFailSteps,
        IEnumerable<IOnExceptionStep<TError, TContext>> onExceptionSteps)
        => Flow(steps, _context, onFailSteps, onExceptionSteps);

    private static Either<TError, TContext> Flow<TError>(
        IEnumerable<IConditionalStep<TError, TContext>> steps,
        TContext context,
        IEnumerable<IOnErrorStep<TError, TContext>> onFailSteps,
        IEnumerable<IOnExceptionStep<TError, TContext>> onExceptionSteps)
        => Try(() => steps
                    .Fold(Either<TError, TContext>.Right(context),
                         (state, step) => state
                                            .Bind(_ => step.ToOption(__ => !__.ExecutionCondition(_))
                                                           .Map(__ => __.Forward(_))
                                                           .OrElse(_)))
                    .BindLeft(error => onFailSteps
                                      .ToOption(_ => !_.Any())
                                      .Map(_ => _.Fold(Right<TError, TContext>(context),
                                                      (state, step) => state.Bind(_ => step.Forward(_, error))))
                                      .OrElse(error)))
        .OnFail(ex => onExceptionSteps
                     .Fold(Right<TError, TContext>(context),
                          (context, step) => context.Bind(_ => step.Forward(_, ex))));

    private static Task<Either<TError, TContext>> Flow<TError>(
    IEnumerable<IConditionalAsyncStep<TError, TContext>> steps,
    TContext context,
    IEnumerable<IOnErrorAsyncStep<TError, TContext>> onFailSteps,
    IEnumerable<IOnExceptionAsyncStep<TError, TContext>> onExceptionSteps)
    => TryAsync(() => steps
                      .FoldAsync(Right<TError, TContext>(context),
                                (state, step) => state.BindAsync(_ => step.ToOption(__ => !__.ExecutionCondition(_))
                                                                          .Map(__ => __.Forward(_))
                                                                          .OrElse(state.AsTask())))
                       .BindLeftAsync(error => onFailSteps
                                                 .ToOption(_ => !_.Any())
                                                 .Map(_ => _.FoldAsync(Right<TError, TContext>(context),
                                                                      (state, step) => state.BindAsync(_ => step.Forward(_, error))))
                                                 .OrElse(Left<TError, TContext>(error).AsTask())))
    .OnFail(ex => onExceptionSteps
                 .FoldAsync(Right<TError, TContext>(context),
                           (context, step) => context.BindAsync(_ => step.Forward(_, ex))));
}