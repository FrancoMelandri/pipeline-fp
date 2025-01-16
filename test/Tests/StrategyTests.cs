using NUnit.Framework;
using PipelineFpTest.Strategy;
using Shouldly;

namespace PipelineFpTest.Tests;

internal class StrategyTests
{
    [TestCase("first", "A")]
    [TestCase("second", "B")]
    [TestCase("third", "C")]
    public void WhenUsingPatternMatching_ResolveTheRightStrategy(string selector, string expected)
    => StrategyUseCase
    .ResolveUsingPatternMatching(selector, ["A", "B", "C"])
    .ShouldBe(expected);

    [TestCase("first", "First strategy error")]
    [TestCase("second", "Second strategy error")]
    [TestCase("third", "Third strategy error")]
    public void WhenUsingPatternMatching_AndThereIsAnEror_ResolveTheRightStrategy(string selector, string expected)
        => StrategyUseCase
        .ResolveUsingPatternMatching(selector, [])
        .ShouldBe(expected);

    [TestCase("first", "A")]
    [TestCase("second", "B")]
    [TestCase("third", "C")]
    public void WhenUsingAsyncPatternMatching_ResolveTheRightStrategy(string selector, string expected)
        => StrategyUseCase
        .ResolveUsingAsyncPatternMatching(selector, ["A", "B", "C"])
        .Result
        .ShouldBe(expected);

    [TestCase("first", "First strategy error")]
    [TestCase("second", "Second strategy error")]
    [TestCase("third", "Third strategy error")]
    public void WhenUsingAsyncPatternMatching_AndThereIsAnEror_ResolveTheRightStrategy(string selector, string expected)
        => StrategyUseCase
        .ResolveUsingAsyncPatternMatching(selector, [])
        .Result
        .ShouldBe(expected);
}
