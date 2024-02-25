using PipelineFp.Pipelines;
using TinyFp;
using TinyFp.Extensions;
using static PipelineFpTest.Switch.BasicPipelineConstants.Selectors;
using static TinyFp.Prelude;

namespace PipelineFpTest.Switch.HashedPipeline;

internal class SwitchNorthHashedStep : IHashedStep<SwitchHashedContext, SwitchSelector>
{
    public SwitchSelector Hash => SwitchSelector.North;

    public Either<Unit, SwitchHashedContext> Forward(SwitchHashedContext context)
        => context.With(NorthSelector)
        .Map(Right<Unit, SwitchHashedContext>);
}