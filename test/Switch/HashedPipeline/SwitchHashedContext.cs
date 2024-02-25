using PipelineFp.Pipelines;

namespace PipelineFpTest.Switch.HashedPipeline;

internal class SwitchHashedContext : IHashedContext<SwitchSelector>
{
    public SwitchSelector Selector { get; }
    internal string Result { get; }

    private SwitchHashedContext(SwitchSelector selector,
        string result)
    {
        Result = result;
        Selector = selector;
    }
    internal static SwitchHashedContext With(SwitchSelector selector)
        => new(selector,
            string.Empty);

    internal SwitchHashedContext With(string result)
        => new(Selector,
            result);
}