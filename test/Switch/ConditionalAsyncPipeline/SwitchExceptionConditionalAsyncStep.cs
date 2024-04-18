using PipelineFp.Steps;
using PipelineFpTest.DataTypes;
using TinyFp;

namespace PipelineFpTest.Switch.ConditionalAsyncPipeline;

internal class SwitchExceptionConditionalAsyncStep : IConditionalAsyncStep<Error, SwitchContext>
{
    public Predicate<SwitchContext> ExecutionCondition => context => true;

    public Task<Either<Error, SwitchContext>> Forward(SwitchContext context)
        => throw new Exception("Exception");
}

