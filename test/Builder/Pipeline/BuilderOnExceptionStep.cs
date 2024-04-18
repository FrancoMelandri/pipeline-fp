using PipelineFp.Steps;
using PipelineFpTest.DataTypes;
using TinyFp;
using static PipelineFpTest.Builder.Constants.Steps;

namespace PipelineFpTest.Builder.Pipeline;

internal class BuilderOnExceptionStep : IOnExceptionStep<Error, BuilderStepsContext>
{
    public Either<Error, BuilderStepsContext> Forward(BuilderStepsContext context, Exception ex)
       => Either<Error, BuilderStepsContext>.Right(context)
    .Map(_ => UpdateContext(_, ex));

    private static BuilderStepsContext UpdateContext(BuilderStepsContext context, Exception ex)
    => context.With($"Exception Handled: {ex.Message}. Executed steps: {string.Join(Joiner, context.Steps)}");
}
