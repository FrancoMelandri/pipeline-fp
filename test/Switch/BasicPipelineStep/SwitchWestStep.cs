using PipelineFp.Pipelines;
using TinyFp;
using TinyFp.Extensions;
using static TinyFp.Prelude;

namespace PipelineFpTest.Switch.BasicPipelineStep;

internal class SwitchWestStep : IStep<SwitchContext>
{
    public Either<Unit, SwitchContext> Forward(SwitchContext context)
        => Right<Unit, SwitchContext>(context)
        .Map(UpdateContext);

    private static SwitchContext UpdateContext(SwitchContext context)
        => context
        .ToOption(_ => _.InputSelector != SwitchSelector.West)
        .Map(_ => _.With("West selector"))
        .OrElse(context);
}