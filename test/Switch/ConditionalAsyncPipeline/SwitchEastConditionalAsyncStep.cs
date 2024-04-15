using PipelineFp.Steps;
using PipelineFpTest.DataTypes;
using TinyFp;
using TinyFp.Extensions;
using static PipelineFpTest.Switch.Constants.Selectors;

namespace PipelineFpTest.Switch.ConditionalAsyncPipeline;

internal class SwitchEastConditionalAsyncStep : IConditionalAsyncStep<Error, SwitchContext>
{
    public Predicate<SwitchContext> ExecutionCondition => context => context.InputSelector == SwitchSelector.East;

    public Task<Either<Error, SwitchContext>> Forward(SwitchContext context)
        => context.With(EastSelector)
        .Map(Either<Error, SwitchContext>.Right)
        .AsTask();
}