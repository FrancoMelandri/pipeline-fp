using PipelineFp.Patterns;
using PipelineFpTest.DataTypes;
using TinyFp;

namespace PipelineFpTest.Switch.AsyncMatchingPipeline;

internal class SwitchAsyncOnError : IAsyncOnErrorCallback<Error, SwitchPatternAsyncContext>
{
    public Task<Either<Error, SwitchPatternAsyncContext>> OnError(SwitchPatternAsyncContext context, Error error)
        => Either<Error, SwitchPatternAsyncContext>.Right(context.With("Error")).AsTask();
}