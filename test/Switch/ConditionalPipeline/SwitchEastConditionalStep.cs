using PipelineFp.Steps;
using PipelineFpTest.DataTypes;
using TinyFp;
using TinyFp.Extensions;
using static PipelineFpTest.Switch.Constants.Selectors;

namespace PipelineFpTest.Switch.ConditionalPipeline;

internal class SwitchEastConditionalStep : IConditionalStep<Error, SwitchContext>
{
    public Predicate<SwitchContext> ExecutionCondition => context => context.InputSelector == SwitchSelector.East;

    public Either<Error, SwitchContext> Forward(SwitchContext context)
        => context.With(EastSelector)
        .Map(Either<Error, SwitchContext>.Right);
}