using PipelineFp.Steps;
using PipelineFpTest.DataTypes;
using TinyFp;

namespace PipelineFpTest.MixedPipeline.Steps;

internal class ExceptionHandlingStep : IOnExceptionStep<Error, MixedPipelineContext>
{
    public Either<Error, MixedPipelineContext> Forward(MixedPipelineContext context, Exception ex)
        => Either<Error, MixedPipelineContext>.Right(context)
        .Map(_ => _.WithResult($"{_.Result}: {ex.Message}"));
}