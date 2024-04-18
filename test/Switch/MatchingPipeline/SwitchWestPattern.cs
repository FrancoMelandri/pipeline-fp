using PipelineFpTest.DataTypes;
using TinyFp;
using TinyFp.Extensions;

namespace PipelineFpTest.Switch.MatchingPipeline;

internal class SwitchWestPattern : IPattern<Error, SwitchPatternContext, SwitchSelector>
{
    public SwitchSelector Selector => SwitchSelector.West;

    public Either<Error, SwitchPatternContext> Match(SwitchPatternContext context)
        => context.With("West")
        .Map(Either<Error, SwitchPatternContext>.Right);
}