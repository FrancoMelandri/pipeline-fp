using PipelineFp.Steps;
using PipelineFpTest.DataTypes;
using TinyFp;

namespace PipelineFpTest.MixedPipeline.Steps;

internal class ErrorHandlingStep : IOnErrorStep<Error, MixedPipelineContext>
{
    public Either<Error, MixedPipelineContext> Forward(MixedPipelineContext context, Error error)
        => Either<Error, MixedPipelineContext>.Right(context)
        .Map(_ => _.WithResult($"{_.Result}: {error.Message}"));
}