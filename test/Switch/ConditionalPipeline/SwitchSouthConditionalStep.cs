using PipelineFp.Steps;
using PipelineFpTest.DataTypes;
using TinyFp;
using TinyFp.Extensions;
using static PipelineFpTest.Switch.Constants.Selectors;

namespace PipelineFpTest.Switch.ConditionalPipeline;

internal class SwitchSouthConditionalStep : IConditionalStep<Error, SwitchContext>
{
    public Predicate<SwitchContext> ExecutionCondition => context => context.InputSelector == SwitchSelector.South;

    public Either<Error, SwitchContext> Forward(SwitchContext context)
        => context.With(SouthSelector)
        .Map(Either<Error, SwitchContext>.Right);
}
