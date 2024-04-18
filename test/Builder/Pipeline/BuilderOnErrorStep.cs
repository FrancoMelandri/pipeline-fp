using PipelineFp.Steps;
using PipelineFpTest.DataTypes;
using TinyFp;
using TinyFp.Extensions;
using static PipelineFpTest.Builder.Constants.Steps;

namespace PipelineFpTest.Builder.Pipeline;

internal class BuilderOnErrorStep : IOnErrorStep<Error, BuilderStepsContext>
{
    public Either<Error, BuilderStepsContext> Forward(BuilderStepsContext context, Error error)
        => context.With($"Error Handled: {error.Message}. Executed steps: {string.Join(Joiner, context.Steps)}")
         .Map(Either<Error, BuilderStepsContext>.Right);
}
