using PipelineFp.Patterns;
using PipelineFpTest.DataTypes;
using TinyFp;

namespace PipelineFpTest.Switch.AsyncMatchingPipeline;

internal class SwitchExceptionAsyncPattern : IAsyncPattern<Error, SwitchPatternAsyncContext, SwitchSelector>
{
    public SwitchSelector Selector => SwitchSelector.Exception;

    public Task<Either<Error, SwitchPatternAsyncContext>> Match(SwitchPatternAsyncContext context)
        => throw new Exception("Exception");
}
