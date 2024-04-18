using PipelineFp.Steps;
using PipelineFpTest.DataTypes;
using TinyFp;

namespace PipelineFpTest.Switch.ConditionalAsyncPipeline;

internal class SwitchOnExceptionAsyncStep : IOnExceptionAsyncStep<Error, SwitchContext>
{
    public Task<Either<Error, SwitchContext>> Forward(SwitchContext context, Exception ex)
       => Either<Error, SwitchContext>.Right(context)
       .MapAsync(_ => UpdateContext(_, ex));

    private static Task<SwitchContext> UpdateContext(SwitchContext context, Exception ex)
    => context.With($"Exception Handled: {ex.Message}")
        .AsTask();
}

