using PipelineFpTest.DataTypes;
using TinyFp;

namespace PipelineFpTest.Switch.MatchingPipeline;

internal class SwitchExceptionPattern : IPattern<Error, SwitchPatternContext, SwitchSelector>
{
    public SwitchSelector Selector => SwitchSelector.Exception;

    public Either<Error, SwitchPatternContext> Match(SwitchPatternContext context)
        => throw new Exception("Exception");
}
