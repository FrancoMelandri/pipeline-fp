using PipelineFp.Steps;
using PipelineFpTest.DataTypes;
using TinyFp;

namespace PipelineFpTest.MixedPipeline.Steps;

internal class SimpleStep : IStep<Error, MixedPipelineContext>
{
    public Either<Error, MixedPipelineContext> Forward(MixedPipelineContext context)
        => Either<Error, MixedPipelineContext>.Right(context)
        .Map(_ => _.With(["Simple"]));
}