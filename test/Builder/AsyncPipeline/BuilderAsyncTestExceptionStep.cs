using PipelineFp.Steps;
using PipelineFpTest.DataTypes;
using TinyFp;

namespace PipelineFpTest.Builder.AsyncPipeline;

internal class BuilderAsyncTestExceptionStep : IAsyncStep<Error, BuilderAsyncStepsContext>
{
    public Task<Either<Error, BuilderAsyncStepsContext>> Forward(BuilderAsyncStepsContext context)
        => throw new Exception("Exception");
}

