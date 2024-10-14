using PipelineFp.Steps;
using PipelineFpTest.DataTypes;
using TinyFp;

namespace PipelineFpTest.MixedPipeline.AsyncSteps;

internal class ExceptionHandlingAsyncStep : IOnExceptionAsyncStep<Error, MixedPipelineContext>
{
    public Task<Either<Error, MixedPipelineContext>> Forward(MixedPipelineContext context, Exception exception)
        => Either<Error, MixedPipelineContext>.Right(context)
        .Map(_ => _.WithResult($"{_.Result}: {exception.Message}"))
        .AsTask();
}