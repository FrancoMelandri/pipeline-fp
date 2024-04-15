using PipelineFp.Patterns;
using PipelineFpTest.DataTypes;
using TinyFp;
using TinyFp.Extensions;

namespace PipelineFpTest.Switch.AsyncMatchingPipeline;

internal class SwitchNoneAsyncPattern : IAsyncPattern<Error, SwitchPatternAsyncContext, SwitchSelector>
{
    public SwitchSelector Selector => SwitchSelector.None;

    public Task<Either<Error, SwitchPatternAsyncContext>> Match(SwitchPatternAsyncContext context)
        => context.With("None")
        .Map(Either<Error, SwitchPatternAsyncContext>.Right)
        .AsTask();
}
