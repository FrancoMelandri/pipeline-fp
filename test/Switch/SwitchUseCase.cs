using PipelineFp.Pipelines;
using PipelineFpTest.Switch.BasicPipelineStep;
using TinyFp.Extensions;

namespace PipelineFpTest.Switch;

public static class SwitchUseCase
{
    public static string ResolveUsingSwitch(SwitchSelector switchSelector)
        => switchSelector switch
        {
            SwitchSelector.None => "None selector",
            SwitchSelector.North => "North selector",
            SwitchSelector.South => "South selector",
            SwitchSelector.West => "West selector",
            SwitchSelector.East => "East selector"
        };

    public static string ResolveUsingBasicPipeline(SwitchSelector switchSelector)
        => new List<IStep<SwitchContext>>
        {
            new SwitchNoneStep(),
            new SwitchNorthStep(),
            new SwitchEastStep(),
            new SwitchSouthStep(),
            new SwitchWestStep(),
        }
        .Map(steps => SwitchContext
                      .With(switchSelector)
                      .Map(context => BasicPipeline<SwitchContext>
                                      .Evaluate(steps, context)))
        .Match(_ => _.Result,
               _ => string.Empty);
}