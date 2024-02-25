using PipelineFp.Pipelines;
using TinyFp;
using TinyFp.Extensions;
using static PipelineFpTest.Switch.BasicPipelineConstants.Selectors;
using static TinyFp.Prelude;

namespace PipelineFpTest.Switch.HashedPipeline;

internal class SwitchSouthHashedStep : IHashedStep<SwitchHashedContext, SwitchSelector>
{
    public SwitchSelector Hash => SwitchSelector.South;

    public Either<Unit, SwitchHashedContext> Forward(SwitchHashedContext context)
        => context.With(SouthSelector)
        .Map(Right<Unit, SwitchHashedContext>);
}