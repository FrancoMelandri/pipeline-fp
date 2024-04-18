using TinyFp.Extensions;

namespace PipelineFpTest.Switch;

internal class SwitchContext
{
    internal SwitchSelector InputSelector { get; }
    internal string Result { get; private set; }

    private SwitchContext(
        SwitchSelector inputSelector,
        string result)
    {
        InputSelector = inputSelector;
        Result = result;
    }

    internal static SwitchContext With(SwitchSelector inputSelector)
        => new(inputSelector,
            string.Empty);

    internal SwitchContext With(string result)
        => this.Tee(_ => _.Result = result);
}