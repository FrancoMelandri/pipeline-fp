using PipelineFp.Patterns;
using PipelineFpTest.DataTypes;
using TinyFp;
using TinyFp.Extensions;

namespace PipelineFpTest.Switch.AsyncMatchingPipeline;

internal class SwitchEastAsyncPattern : IAsyncPattern<Error, SwitchPatternAsyncContext, SwitchSelector>
{
    public SwitchSelector Selector => SwitchSelector.East;

    public Task<Either<Error, SwitchPatternAsyncContext>> Match(SwitchPatternAsyncContext context)
        => context.With("East")
        .Map(Either<Error, SwitchPatternAsyncContext>.Right)
        .AsTask();
}
