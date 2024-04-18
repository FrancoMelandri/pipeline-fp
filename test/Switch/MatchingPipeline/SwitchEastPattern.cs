using PipelineFpTest.DataTypes;
using TinyFp;
using TinyFp.Extensions;

namespace PipelineFpTest.Switch.MatchingPipeline;

internal class SwitchEastPattern : IPattern<Error, SwitchPatternContext, SwitchSelector>
{
    public SwitchSelector Selector => SwitchSelector.East;

    public Either<Error, SwitchPatternContext> Match(SwitchPatternContext context)
        => context.With("East")
        .Map(Either<Error, SwitchPatternContext>.Right);
}