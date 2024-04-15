using PipelineFpTest.DataTypes;
using TinyFp;
using TinyFp.Extensions;

namespace PipelineFpTest.Switch.MatchingPipeline;

internal class SwitchSouthPattern : IPattern<Error, SwitchPatternContext, SwitchSelector>
{
    public SwitchSelector Selector => SwitchSelector.South;

    public Either<Error, SwitchPatternContext> Match(SwitchPatternContext context)
        => context.With("South")
        .Map(Either<Error, SwitchPatternContext>.Right);
}
