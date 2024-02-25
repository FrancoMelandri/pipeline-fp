using PipelineFp.Pipelines;
using TinyFp;
using TinyFp.Extensions;
using static PipelineFpTest.Switch.BasicPipelineConstants.Selectors;
using static TinyFp.Prelude;

namespace PipelineFpTest.Switch.BasicPipelineStep;

internal class SwitchSouthStep : IBasicStep<SwitchContext>
{
    public Either<Unit, SwitchContext> Forward(SwitchContext context)
        => Right<Unit, SwitchContext>(context)
        .Map(UpdateContext);

    private static SwitchContext UpdateContext(SwitchContext context)
        => context
        .ToOption(_ => _.InputSelector != SwitchSelector.South)
        .Map(_ => _.With(SouthSelector))
        .OrElse(context);
}