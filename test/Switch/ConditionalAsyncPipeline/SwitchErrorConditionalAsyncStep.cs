using PipelineFp.Steps;
using PipelineFpTest.DataTypes;
using TinyFp;

namespace PipelineFpTest.Switch.ConditionalAsyncPipeline;

internal class SwitchErrorConditionalAsyncStep : IConditionalAsyncStep<Error, SwitchContext>
{
    public Predicate<SwitchContext> ExecutionCondition => context => true;

    public Task<Either<Error, SwitchContext>> Forward(SwitchContext context)
        => TinyFp.Prelude.Left<Error, SwitchContext>(new Error
        {
            Message = "Error"
        }).AsTask();
}

