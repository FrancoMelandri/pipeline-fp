using PipelineFp.Pipelines;
using PipelineFpTest.Switch;
using TinyFp;
using TinyFp.Extensions;
using static PipelineFpTest.Builder.BasicPipelineStep.BasicPipelineConstants.Steps;
using static TinyFp.Prelude;

namespace PipelineFpTest.Builder.BasicPipelineStep;

internal class BuilderThirdStep : IBasicStep<BuilderStepsContext>
{
    public Either<Unit, BuilderStepsContext> Forward(BuilderStepsContext context)
        => Right<Unit, BuilderStepsContext>(context)
        .Map(UpdateContext);

    private static BuilderStepsContext UpdateContext(BuilderStepsContext context)
        => context
        .ToOption(_ => !_.InputStep.HasFlag(BuilderStep.Third))
        .Map(_ => _.With([.. _.Steps, Third]))
        .OrElse(context);
}