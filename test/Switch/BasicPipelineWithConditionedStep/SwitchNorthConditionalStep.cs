using PipelineFp.Pipelines;
using TinyFp;
using TinyFp.Extensions;
using static PipelineFpTest.Switch.BasicPipelineConstants.Selectors;
using static TinyFp.Prelude;

namespace PipelineFpTest.Switch.BasicPipelineWithConditionedStep;

internal class SwitchNorthConditionalStep : IConditionalStep<SwitchContext>
{
    public Predicate<SwitchContext> ExecutionCondition => context => context.InputSelector == SwitchSelector.North;

    public Either<Unit, SwitchContext> Forward(SwitchContext context)
        => context.With(NorthSelector)
        .Map(Right<Unit, SwitchContext>);
}