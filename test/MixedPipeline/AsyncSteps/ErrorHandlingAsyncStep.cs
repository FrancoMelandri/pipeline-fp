using PipelineFp.Steps;
using PipelineFpTest.DataTypes;
using TinyFp;

namespace PipelineFpTest.MixedPipeline.AsyncSteps;

internal class ErrorHandlingAsyncStep : IOnErrorAsyncStep<Error, MixedPipelineContext>
{
    public Task<Either<Error, MixedPipelineContext>> Forward(MixedPipelineContext context, Error error)
        => Either<Error, MixedPipelineContext>.Right(context)
        .Map(_ => _.WithResult($"{_.Result}: {error.Message}"))
        .AsTask();
}
