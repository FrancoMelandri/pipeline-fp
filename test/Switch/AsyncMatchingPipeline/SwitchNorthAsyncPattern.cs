using PipelineFp.Patterns;
using PipelineFpTest.DataTypes;
using TinyFp;
using TinyFp.Extensions;

namespace PipelineFpTest.Switch.AsyncMatchingPipeline;

internal class SwitchNorthAsyncPattern : IAsyncPattern<Error, SwitchPatternAsyncContext, SwitchSelector>
{
    public SwitchSelector Selector => SwitchSelector.North;

    public Task<Either<Error, SwitchPatternAsyncContext>> Match(SwitchPatternAsyncContext context)
        => context.With("North")
        .Map(Either<Error, SwitchPatternAsyncContext>.Right)
        .AsTask();
}
