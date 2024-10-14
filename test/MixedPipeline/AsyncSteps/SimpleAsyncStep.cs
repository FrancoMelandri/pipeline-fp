using PipelineFp.Steps;
using PipelineFpTest.DataTypes;
using TinyFp;

namespace PipelineFpTest.MixedPipeline.AsyncSteps;

internal class SimpleAsyncStep : IAsyncStep<Error, MixedPipelineContext>
{
    public Task<Either<Error, MixedPipelineContext>> Forward(MixedPipelineContext context)
        => Either<Error, MixedPipelineContext>.Right(context)
        .Map(_ => _.With(["Simple"]))
        .AsTask();
}