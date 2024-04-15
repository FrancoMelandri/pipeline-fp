using PipelineFp.Steps;
using PipelineFpTest.DataTypes;
using TinyFp;

namespace PipelineFpTest.Builder.AsyncPipeline;

internal class BuilderAsyncTestErrorStep : IAsyncStep<Error, BuilderAsyncStepsContext>
{
    public Task<Either<Error, BuilderAsyncStepsContext>> Forward(BuilderAsyncStepsContext context)
        => Either<Error, BuilderAsyncStepsContext>.Left(new Error
        {
            Message = "TestError"
        }).AsTask();
}

