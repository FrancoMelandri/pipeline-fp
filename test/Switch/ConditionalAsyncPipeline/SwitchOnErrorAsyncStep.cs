using PipelineFp.Steps;
using PipelineFpTest.DataTypes;
using TinyFp;
using TinyFp.Extensions;

namespace PipelineFpTest.Switch.ConditionalAsyncPipeline;

internal class SwitchOnErrorAsyncStep : IOnErrorAsyncStep<Error, SwitchContext>
{
    public Task<Either<Error, SwitchContext>> Forward(SwitchContext context, Error error)
        => context.With($"Error Handled: {error.Message}")
        .Map(Either<Error, SwitchContext>.Right)
        .AsTask();
}

