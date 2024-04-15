using PipelineFpTest.DataTypes;
using TinyFp;
using TinyFp.Extensions;

namespace PipelineFpTest.Switch.MatchingPipeline;

internal class SwitchNorthPattern : IPattern<Error, SwitchPatternContext, SwitchSelector>
{
    public SwitchSelector Selector => SwitchSelector.North;

    public Either<Error, SwitchPatternContext> Match(SwitchPatternContext context)
        => context.With("North")
        .Map(Either<Error, SwitchPatternContext>.Right);
}
