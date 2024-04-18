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
        => new BuilderUseCase()
            .ResolveUsingIf(steps)
            .Should()
            .Be(expected);

    [TestCase(BuilderStep.None | BuilderStep.First, "First")]
    [TestCase(BuilderStep.None | BuilderStep.Second, "Second")]
    [TestCase(BuilderStep.None | BuilderStep.Third, "Third")]
    [TestCase(BuilderStep.First | BuilderStep.Second, "First,Second")]
    [TestCase(BuilderStep.Second | BuilderStep.Third, "Second,Third")]
    public void WhenUsingAsyncPipeline_ResolveTheRightSteps(BuilderStep steps, string expected)
    => BuilderUseCase
    .ResolveUsingAsyncPipeline(steps)
    .Result
    .Should()
    .Be(expected);

    [TestCase(BuilderStep.None | BuilderStep.First, "Error Handled: TestError. Executed steps: First")]
    [TestCase(BuilderStep.None | BuilderStep.Second, "Error Handled: TestError. Executed steps: Second")]
    [TestCase(BuilderStep.None | BuilderStep.Third, "Error Handled: TestError. Executed steps: ")]
    [TestCase(BuilderStep.First | BuilderStep.Second, "Error Handled: TestError. Executed steps: First,Second")]
    [TestCase(BuilderStep.Second | BuilderStep.Third, "Error Handled: TestError. Executed steps: Second")]
    public void WhenUsingAsyncPipeline_WhenError_ResolveTheRightSteps(BuilderStep steps, string expected)
        => BuilderUseCase
        .ResolveUsingAsyncPipelineInCaseOfError(steps)
        .Result
        .Should()
        .Be(expected);

    [TestCase(BuilderStep.None | BuilderStep.First, "TestError")]
    [TestCase(BuilderStep.None | BuilderStep.Second, "TestError")]
    [TestCase(BuilderStep.None | BuilderStep.Third, "TestError")]
    [TestCase(BuilderStep.First | BuilderStep.Second, "TestError")]
    [TestCase(BuilderStep.Second | BuilderStep.Third, "TestError")]
    public void WhenUsingAsyncPipeline_WhenError_AndNotErrorSteps_ResolveTheRightSteps(BuilderStep steps, string expected)
        => BuilderUseCase
        .ResolveUsingAsyncPipelineInCaseOfErrorWithoutErrorSteps(steps)
        .Result
        .Should()
        .Be(expected);

    [TestCase(BuilderStep.None | BuilderStep.First, "Exception Handled: Exception. Executed steps: First")]
    [TestCase(BuilderStep.None | BuilderStep.Second, "Exception Handled: Exception. Executed steps: Second")]
    [TestCase(BuilderStep.None | BuilderStep.Third, "Exception Handled: Exception. Executed steps: ")]
    [TestCase(BuilderStep.First | BuilderStep.Second, "Exception Handled: Exception. Executed steps: First,Second")]
    [TestCase(BuilderStep.Second | BuilderStep.Third, "Exception Handled: Exception. Executed steps: Second")]
    public void WhenUsingAsyncPipeline_WhenException_ResolveTheRightSteps(BuilderStep steps, string expected)
        => BuilderUseCase
        .ResolveUsingAsyncPipelineInCaseOfException(steps)
        .Result
        .Should()
        .Be(expected);

    [TestCase(BuilderStep.None | BuilderStep.First, "First")]
    [TestCase(BuilderStep.None | BuilderStep.Second, "Second")]
    [TestCase(BuilderStep.None | BuilderStep.Third, "Third")]
    [TestCase(BuilderStep.First | BuilderStep.Second, "First,Second")]
    [TestCase(BuilderStep.Second | BuilderStep.Third, "Second,Third")]
    public void WhenUsingPipeline_ResolveTheRightSteps(BuilderStep steps, string expected)
        => BuilderUseCase
        .ResolveUsingPipeline(steps)
        .Should()
        .Be(expected);

    [TestCase(BuilderStep.None | BuilderStep.First, "Error Handled: TestError. Executed steps: First")]
    [TestCase(BuilderStep.None | BuilderStep.Second, "Error Handled: TestError. Executed steps: Second")]
    [TestCase(BuilderStep.None | BuilderStep.Third, "Error Handled: TestError. Executed steps: ")]
    [TestCase(BuilderStep.First | BuilderStep.Second, "Error Handled: TestError. Executed steps: First,Second")]
    [TestCase(BuilderStep.Second | BuilderStep.Third, "Error Handled: TestError. Executed steps: Second")]
    public void WhenUsingPipeline_WhenError_ResolveTheRightSteps(BuilderStep steps, string expected)
        => BuilderUseCase
        .ResolveUsingPipelineInCaseOfError(steps)
        .Should()
        .Be(expected);

    [TestCase(BuilderStep.None | BuilderStep.First, "Exception Handled: Exception. Executed steps: First")]
    [TestCase(BuilderStep.None | BuilderStep.Second, "Exception Handled: Exception. Executed steps: Second")]
    [TestCase(BuilderStep.None | BuilderStep.Third, "Exception Handled: Exception. Executed steps: ")]
    [TestCase(BuilderStep.First | BuilderStep.Second, "Exception Handled: Exception. Executed steps: First,Second")]
    [TestCase(BuilderStep.Second | BuilderStep.Third, "Exception Handled: Exception. Executed steps: Second")]
    public void WhenUsingPipeline_WhenException_ResolveTheRightSteps(BuilderStep steps, string expected)
        => BuilderUseCase
        .ResolveUsingPipelineInCaseOfException(steps)
        .Should()
        .Be(expected);

    [TestCase(BuilderStep.None | BuilderStep.First, "TestError")]
    [TestCase(BuilderStep.None | BuilderStep.Second, "TestError")]
    [TestCase(BuilderStep.None | BuilderStep.Third, "TestError")]
    [TestCase(BuilderStep.First | BuilderStep.Second, "TestError")]
    [TestCase(BuilderStep.Second | BuilderStep.Third, "TestError")]
    public void WhenUsingPipeline_WhenError_AndNotErrorHandler_ResolveTheRightSteps(BuilderStep steps, string expected)
        => BuilderUseCase
        .ResolveUsingPipelineInCaseOfErrorWithoutErrorSteps(steps)
        .Should()
        .Be(expected);
}