using PipelineFp.Pipelines;
using TinyFp;
using TinyFp.Extensions;
using static PipelineFpTest.Builder.BasicPipelineStep.BasicPipelineConstants.Steps;
using static TinyFp.Prelude;

namespace PipelineFpTest.Builder.BasicPipelineStep;

internal class BuilderJoinStep : IStep<BuilderStepsContext>
{
    public Either<Unit, BuilderStepsContext> Forward(BuilderStepsContext context)
        => Right<Unit, BuilderStepsContext>(context)
        .Map(UpdateContext);

    private static BuilderStepsContext UpdateContext(BuilderStepsContext context)
        => context
        .ToOption()
        .Map(_ => _.With(string.Join(Joiner, _.Steps)))
        .OrElse(context);
}