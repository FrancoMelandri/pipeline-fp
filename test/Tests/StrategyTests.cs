using FluentAssertions;
using NUnit.Framework;
using PipelineFpTest.Strategy;

namespace PipelineFpTest.Tests;

internal class StrategyTests
{
    [TestCase("first", "A")]
    [TestCase("second", "B")]
    [TestCase("third", "C")]
    public void WhenUsingPatternMatching_ResolveTheRightStrategy(string selector, string expected)
    => StrategyUseCase
    .ResolveUsingPatternMatching(selector, ["A", "B", "C"])
    .Should()
    .Be(expected);

    [TestCase("first", "First strategy error")]
    [TestCase("second", "Second strategy error")]
    [TestCase("third", "Third strategy error")]
    public void WhenUsingPatternMatching_AndThereIsAnEror_ResolveTheRightStrategy(string selector, string expected)
        => StrategyUseCase
        .ResolveUsingPatternMatching(selector, [])
        .Should()
        .Be(expected);

    [TestCase("first", "A")]
    [TestCase("second", "B")]
    [TestCase("third", "C")]
    public void WhenUsingAsyncPatternMatching_ResolveTheRightStrategy(string selector, string expected)
        => StrategyUseCase
        .ResolveUsingAsyncPatternMatching(selector, ["A", "B", "C"])
        .Result
        .Should()
        .Be(expected);

    [TestCase("first", "First strategy error")]
    [TestCase("second", "Second strategy error")]
    [TestCase("third", "Third strategy error")]
    public void WhenUsingAsyncPatternMatching_AndThereIsAnEror_ResolveTheRightStrategy(string selector, string expected)
        => StrategyUseCase
        .ResolveUsingAsyncPatternMatching(selector, [])
        .Result
        .Should()
        .Be(expected);
}
