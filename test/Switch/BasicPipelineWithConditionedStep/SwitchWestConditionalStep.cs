using PipelineFp.Pipelines;
using TinyFp;
using TinyFp.Extensions;
using static PipelineFpTest.Switch.BasicPipelineConstants.Selectors;

using static TinyFp.Prelude;

namespace PipelineFpTest.Switch.BasicPipelineWithConditionedStep;

internal class SwitchWestConditionalStep : IConditionalStep<SwitchContext>
{
    public Predicate<SwitchContext> ExecutionCondition => context => context.InputSelector == SwitchSelector.West;

    public Either<Unit, SwitchContext> Forward(SwitchContext context)
        => context.With(WestSelector)
        .Map(Right<Unit, SwitchContext>);
}