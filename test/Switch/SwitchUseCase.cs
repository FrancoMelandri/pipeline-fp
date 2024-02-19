namespace PipelineFpTest.Switch;

public class SwitchUseCase
{
    public string ResolveUsingSwitch(SwitchSelector switchSelector)
        => switchSelector switch
        {
            SwitchSelector.None => "None selector",
            SwitchSelector.North => "North selector",
            SwitchSelector.South => "South selector",
            SwitchSelector.West => "West selector",
            SwitchSelector.Est => "Est selector"
        };
}