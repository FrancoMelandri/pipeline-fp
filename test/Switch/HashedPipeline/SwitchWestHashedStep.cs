using PipelineFp.Pipelines;
using TinyFp;
using TinyFp.Extensions;
using static PipelineFpTest.Switch.BasicPipelineConstants.Selectors;

using static TinyFp.Prelude;

namespace PipelineFpTest.Switch.HashedPipeline;

internal class SwitchWestHashedStep : IHashedStep<SwitchHashedContext, SwitchSelector>
{
    public SwitchSelector Hash => SwitchSelector.West;

    public Either<Unit, SwitchHashedContext> Forward(SwitchHashedContext context)
        => context.With(WestSelector)
        .Map(Right<Unit, SwitchHashedContext>);
}