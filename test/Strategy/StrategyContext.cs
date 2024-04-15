using PipelineFp.Contexts;
using TinyFp.Extensions;

namespace PipelineFpTest.Strategy;

internal class StrategyContext : IPatternMatchingContext<string>
{
    public string Selector { get; }
    internal string Result { get; private set; }
    internal string[] Params { get; private set; }

    private StrategyContext(
        string inputSelector,
        string result)
    {
        Selector = inputSelector;
        Result = result;
        Params = [];
    }

    internal static StrategyContext With(string inputSelector)
        => new(inputSelector,
            string.Empty);

    internal StrategyContext WithParams(params string[] @params)
        => this.Tee(_ => _.Params = @params);

    internal StrategyContext WithResult(string result)
        => this.Tee(_ => _.Result = result);
}

