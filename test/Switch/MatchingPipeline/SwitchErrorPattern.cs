using PipelineFpTest.DataTypes;
using TinyFp;

namespace PipelineFpTest.Switch.MatchingPipeline;

internal class SwitchErrorPattern : IPattern<Error, SwitchPatternContext, SwitchSelector>
{
    public SwitchSelector Selector => SwitchSelector.Error;

    public Either<Error, SwitchPatternContext> Match(SwitchPatternContext context)
        => Either<Error, SwitchPatternContext>.Left(new Error
        {
            Message = "Error"
        });
}
