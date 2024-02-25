namespace PipelineFpTest.Switch;

internal class SwitchContext
{
    internal SwitchSelector InputSelector { get; }
    internal string Result { get; }

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
        => new(InputSelector,
            result);
}