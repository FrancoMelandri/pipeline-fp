using FluentAssertions;
using NUnit.Framework;
using PipelineFpTest.Switch;

namespace PipelineFpTest.Tests;

public class SwitchUseCaseTests
{
    [TestCase(SwitchSelector.None, "None selector")]
    [TestCase(SwitchSelector.North, "North selector")]
    [TestCase(SwitchSelector.South, "South selector")]
    [TestCase(SwitchSelector.West, "West selector")]
    [TestCase(SwitchSelector.East, "East selector")]
    public void WhenUsingSwitch_ResolveTheRightString(SwitchSelector selector, string expected)
        => SwitchUseCase
        .ResolveUsingSwitch(selector)
        .Should()
        .Be(expected);

    [TestCase(SwitchSelector.None, "None selector")]
    [TestCase(SwitchSelector.North, "North selector")]
    [TestCase(SwitchSelector.South, "South selector")]
    [TestCase(SwitchSelector.West, "West selector")]
    [TestCase(SwitchSelector.East, "East selector")]
    public void WhenUsingBasicPipeline_ResolveTheRightString(SwitchSelector selector, string expected)
        => SwitchUseCase
        .ResolveUsingBasicPipeline(selector)
        .Should()
        .Be(expected);

    [TestCase(SwitchSelector.None, "None selector")]
    [TestCase(SwitchSelector.North, "North selector")]
    [TestCase(SwitchSelector.South, "South selector")]
    [TestCase(SwitchSelector.West, "West selector")]
    [TestCase(SwitchSelector.East, "East selector")]
    public void WhenUsingBasicPipelineAndConditionedStep_ResolveTheRightString(SwitchSelector selector, string expected)
        => SwitchUseCase
        .ResolveUsingBasicPipelineAndConditionedSteps(selector)
        .Should()
        .Be(expected);
}