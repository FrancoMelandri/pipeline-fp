using PipelineFp.Patterns;
using PipelineFpTest.DataTypes;
using TinyFp;

namespace PipelineFpTest.Switch.AsyncMatchingPipeline;

internal class SwitchErrorAsyncPattern : IAsyncPattern<Error, SwitchPatternAsyncContext, SwitchSelector>
{
    public SwitchSelector Selector => SwitchSelector.Error;

    public Task<Either<Error, SwitchPatternAsyncContext>> Match(SwitchPatternAsyncContext context)
        => Either<Error, SwitchPatternAsyncContext>.Left(new Error
        {
            Message = "Error"
        })
        .AsTask();
}
