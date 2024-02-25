using TinyFp;
using TinyFp.Extensions;

namespace PipelineFp.Pipelines;

public static class BasicPipeline<TContext>
{
    public static Either<Unit, TContext> Evaluate(
        IEnumerable<IStep<TContext>> steps,
        TContext context)
        => steps
        .Fold(Either<Unit, TContext>.Right(context),
             (context, step) => context.Bind(step.Forward));
}