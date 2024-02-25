using PipelineFp.Pipelines;
using TinyFp;
using TinyFp.Extensions;
using static PipelineFpTest.Switch.BasicPipelineConstants.Selectors;

using static TinyFp.Prelude;

namespace PipelineFpTest.Switch.HashedPipeline;

internal class SwitchEastHashedStep : IHashedStep<SwitchHashedContext, SwitchSelector>
{
    public SwitchSelector Hash => SwitchSelector.East;

    public Either<Unit, SwitchHashedContext> Forward(SwitchHashedContext context)
        => context.With(EastSelector)
        .Map(Right<Unit, SwitchHashedContext>);
}