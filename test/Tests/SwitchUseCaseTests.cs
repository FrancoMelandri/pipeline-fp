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
    [TestCase(SwitchSelector.East, "Est selector")]
    public void WhenUsingSwitch_ResolveTheRightString(SwitchSelector selector, string expected)
        => new SwitchUseCase()
            .ResolveUsingSwitch(selector)
            .Should()
            .Be(expected);

    [TestCase(SwitchSelector.None, "None selector")]
    [TestCase(SwitchSelector.North, "North selector")]
    [TestCase(SwitchSelector.South, "South selector")]
    [TestCase(SwitchSelector.West, "West selector")]
    [TestCase(SwitchSelector.East, "East selector")]
    public void WhenUsingConditionalPipeline_ResolveTheRightString(SwitchSelector selector, string expected)
    => SwitchUseCase
    .ResolveUsingConditionalPipeline(selector)
    .Should()
    .Be(expected);

    [TestCase(SwitchSelector.None, "None selector")]
    [TestCase(SwitchSelector.North, "North selector")]
    [TestCase(SwitchSelector.South, "South selector")]
    [TestCase(SwitchSelector.West, "West selector")]
    [TestCase(SwitchSelector.East, "East selector")]
    public void WhenUsingAsyncPipeline_ResolveTheRightString(SwitchSelector selector, string expected)
        => SwitchUseCase
        .ResolveUsingConditionalAsyncPipeline(selector)
        .Result
        .Should()
        .Be(expected);

    [TestCase(SwitchSelector.None, "Error Handled: Error")]
    [TestCase(SwitchSelector.North, "Error Handled: Error")]
    [TestCase(SwitchSelector.South, "Error Handled: Error")]
    [TestCase(SwitchSelector.West, "Error Handled: Error")]
    [TestCase(SwitchSelector.East, "Error Handled: Error")]
    public void WhenUsingAsyncPipeline_AndError_ReturnError(SwitchSelector selector, string expected)
        => SwitchUseCase
        .ResolveUsingConditionalAsyncPipeline_WhenError(selector)
        .Result
        .Should()
        .Be(expected);

    [TestCase(SwitchSelector.None, "Error")]
    [TestCase(SwitchSelector.North, "Error")]
    [TestCase(SwitchSelector.South, "Error")]
    [TestCase(SwitchSelector.West, "Error")]
    [TestCase(SwitchSelector.East, "Error")]
    public void WhenUsingAsyncPipeline_AndError_AndWithoutErrorHandlingSteps_ReturnError(SwitchSelector selector, string expected)
        => SwitchUseCase
        .ResolveUsingConditionalAsyncPipeline_WhenErrorAndWithoutErrorSteps(selector)
        .Result
        .Should()
        .Be(expected);

    [TestCase(SwitchSelector.None, "Exception Handled: Exception")]
    [TestCase(SwitchSelector.North, "Exception Handled: Exception")]
    [TestCase(SwitchSelector.South, "Exception Handled: Exception")]
    [TestCase(SwitchSelector.West, "Exception Handled: Exception")]
    [TestCase(SwitchSelector.East, "Exception Handled: Exception")]
    public void WhenUsingAsyncPipeline_AndError_ReturnException(SwitchSelector selector, string expected)
        => SwitchUseCase
        .ResolveUsingConditionalAsyncPipeline_WhenException(selector)
        .Result
        .Should()
        .Be(expected);

    [TestCase(SwitchSelector.None, "None")]
    [TestCase(SwitchSelector.North, "North")]
    [TestCase(SwitchSelector.South, "South")]
    [TestCase(SwitchSelector.West, "West")]
    [TestCase(SwitchSelector.East, "East")]
    [TestCase(SwitchSelector.Error, "Error")]
    [TestCase(SwitchSelector.Exception, "Exception")]
    public void WhenUsingPatternMatching_ResolveTheRightString(SwitchSelector selector, string expected)
        => SwitchUseCase
        .ResolveUsingPatternMatching(selector)
        .Should()
        .Be(expected);

    [TestCase(SwitchSelector.None, "None")]
    [TestCase(SwitchSelector.North, "North")]
    [TestCase(SwitchSelector.South, "South")]
    [TestCase(SwitchSelector.West, "West")]
    [TestCase(SwitchSelector.East, "East")]
    [TestCase(SwitchSelector.Error, "Error")]
    [TestCase(SwitchSelector.Exception, "Exception")]
    public void WhenUsingAsyncPatternMatching_ResolveTheRightString(SwitchSelector selector, string expected)
        => SwitchUseCase
        .ResolveUsingAsyncPatternMatching(selector)
        .Result
        .Should()
        .Be(expected);
}