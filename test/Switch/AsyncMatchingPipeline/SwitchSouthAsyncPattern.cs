using PipelineFp.Patterns;
using PipelineFpTest.DataTypes;
using TinyFp;
using TinyFp.Extensions;

namespace PipelineFpTest.Switch.AsyncMatchingPipeline;

internal class SwitchSouthAsyncPattern : IAsyncPattern<Error, SwitchPatternAsyncContext, SwitchSelector>
{
    public SwitchSelector Selector => SwitchSelector.South;

    public Task<Either<Error, SwitchPatternAsyncContext>> Match(SwitchPatternAsyncContext context)
        => context.With("South")
        .Map(Either<Error, SwitchPatternAsyncContext>.Right)
        .AsTask();
}
