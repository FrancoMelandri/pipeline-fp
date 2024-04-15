using PipelineFp.Steps;
using PipelineFpTest.DataTypes;
using TinyFp;

namespace PipelineFpTest.Builder.Pipeline;

internal class BuilderTestExceptionStep : IStep<Error, BuilderStepsContext>
{
    public Either<Error, BuilderStepsContext> Forward(BuilderStepsContext context)
        => throw new Exception("Exception");
}
