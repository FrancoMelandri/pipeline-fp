using PipelineFp.Contexts;
using TinyFp.Extensions;

namespace PipelineFpTest.Switch.MatchingPipeline;

internal class SwitchPatternContext : IPatternMatchingContext<SwitchSelector>
{
    public SwitchSelector Selector { get; }
    internal string Result { get; private set; }

    private SwitchPatternContext(SwitchSelector selector,
        string result)
    {
        Result = result;
        Selector = selector;
    }
    internal static SwitchPatternContext With(SwitchSelector selector)
        => new(selector,
            string.Empty);

    internal SwitchPatternContext With(string result)
        => this.Tee(_ => _.Result = result);
}
