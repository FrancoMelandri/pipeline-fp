using PipelineFp.Pipelines;
using TinyFp;
using TinyFp.Extensions;
using static PipelineFpTest.Switch.BasicPipelineConstants.Selectors;

using static TinyFp.Prelude;

namespace PipelineFpTest.Switch.BasicPipelineWithConditionedStep;

internal class SwitchNoneConditionalStep : IConditionalStep<SwitchContext>
{
    public Predicate<SwitchContext> ExecutionCondition => context => context.InputSelector == SwitchSelector.None;

    public Either<Unit, SwitchContext> Forward(SwitchContext context)
        => context.With(NoneSelector)
        .Map(Right<Unit, SwitchContext>);
}