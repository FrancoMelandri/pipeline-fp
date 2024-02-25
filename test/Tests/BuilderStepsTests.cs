using FluentAssertions;
using NUnit.Framework;
using PipelineFpTest.Builder;
using PipelineFpTest.Switch;

namespace PipelineFpTest.Tests;

public class BuilderStepsTests
{
    [TestCase(BuilderStep.None | BuilderStep.First, "First")]
    [TestCase(BuilderStep.None | BuilderStep.Second, "Second")]
    [TestCase(BuilderStep.None | BuilderStep.Third, "Third")]
    [TestCase(BuilderStep.First | BuilderStep.Second, "First,Second")]
    [TestCase(BuilderStep.Second | BuilderStep.Third, "Second,Third")]
    [TestCase(BuilderStep.First | BuilderStep.Second | BuilderStep.Third, "First,Second,Third")]
    public void WhenUsingIf_ResolveTheRightSteps(BuilderStep steps, string expected)
        => BuilderUseCase
        .ResolveUsingIf(steps)
        .Should()
        .Be(expected);

    [TestCase(BuilderStep.None | BuilderStep.First, "First")]
    [TestCase(BuilderStep.None | BuilderStep.Second, "Second")]
    [TestCase(BuilderStep.None | BuilderStep.Third, "Third")]
    [TestCase(BuilderStep.First | BuilderStep.Second, "First,Second")]
    [TestCase(BuilderStep.Second | BuilderStep.Third, "Second,Third")]
    public void WhenUsingBasicPipeline_ResolveTheRightSteps(BuilderStep steps, string expected)
        => BuilderUseCase
        .ResolveUsingBasicPipeline(steps)
        .Should()
        .Be(expected);
}