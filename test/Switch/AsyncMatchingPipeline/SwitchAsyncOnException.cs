using PipelineFp.Patterns;
using PipelineFpTest.DataTypes;
using TinyFp;

namespace PipelineFpTest.Switch.AsyncMatchingPipeline;

internal class SwitchAsyncOnException : IAsyncOnExceptionCallback<Error, SwitchPatternAsyncContext>
{
    public Task<Either<Error, SwitchPatternAsyncContext>> OnException(SwitchPatternAsyncContext context, Exception ex)
        => Either<Error, SwitchPatternAsyncContext>.Right(context.With(ex.Message)).AsTask();
}
