using PipelineFp.Contexts;

namespace PipelineFpTest.Switch.AsyncMatchingPipeline;

internal class SwitchPatternAsyncContext : IPatternMatchingContext<SwitchSelector>
{
    public SwitchSelector Selector { get; }
    internal string Result { get; }

    private SwitchPatternAsyncContext(SwitchSelector selector,
        string result)
    {
        Result = result;
        Selector = selector;
    }
    internal static SwitchPatternAsyncContext With(SwitchSelector selector)
        => new(selector,
            string.Empty);

    internal SwitchPatternAsyncContext With(string result)
        => new(Selector,
            result);
}
