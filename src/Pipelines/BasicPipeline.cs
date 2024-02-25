using TinyFp;
using TinyFp.Extensions;

namespace PipelineFp.Pipelines;

public static class BasicPipeline<TContext>
{
    public static Either<Unit, TContext> Evaluate(
        IEnumerable<IBasicStep<TContext>> steps,
        TContext context)
        => steps
        .Fold(Either<Unit, TContext>.Right(context),
             (context, step) => context.Bind(step.Forward));

    public static Either<Unit, TContext> Evaluate(
        IEnumerable<IConditionalStep<TContext>> steps,
        TContext context)
        => steps
        .Fold(Either<Unit, TContext>.Right(context),
             (context, step) => context
                               .Bind(_ => step
                                         .ToOption(__ => !__.ExecutionCondition(_))
                                         .Map(__ => __.Forward(_))
                                         .OrElse(_)));
}