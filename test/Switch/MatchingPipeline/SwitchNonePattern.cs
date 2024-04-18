using PipelineFpTest.DataTypes;
using TinyFp;
using TinyFp.Extensions;

namespace PipelineFpTest.Switch.MatchingPipeline;

internal class SwitchNonePattern : IPattern<Error, SwitchPatternContext, SwitchSelector>
{
    public SwitchSelector Selector => SwitchSelector.None;

    public Either<Error, SwitchPatternContext> Match(SwitchPatternContext context)
        => context.With("None")
        .Map(Either<Error, SwitchPatternContext>.Right);
}
