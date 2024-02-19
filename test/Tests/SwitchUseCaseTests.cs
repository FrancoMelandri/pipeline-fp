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
    [TestCase(SwitchSelector.Est, "Est selector")]
    public void WhenUsingSwitch_ResolveTheRightString(SwitchSelector selector, string expected)
        => new SwitchUseCase()
            .ResolveUsingSwitch(selector)
            .Should()
            .Be(expected);
}