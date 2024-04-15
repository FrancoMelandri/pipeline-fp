using PipelineFp.Steps;
using PipelineFpTest.DataTypes;
using TinyFp;

namespace PipelineFpTest.Builder.Pipeline;

internal class BuilderTestErrorStep : IStep<Error, BuilderStepsContext>
{
    public Either<Error, BuilderStepsContext> Forward(BuilderStepsContext context)
        => Either<Error, BuilderStepsContext>.Left(new Error
        {
            Message = "TestError"
        });
}
