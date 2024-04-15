using PipelineFp.Patterns;
using PipelineFp.Pipelines;
using PipelineFpTest.DataTypes;
using PipelineFpTest.Strategy.AsyncMatchingPipeline;
using PipelineFpTest.Strategy.MatchingPipeline;
using TinyFp;
using TinyFp.Extensions;

namespace PipelineFpTest.Strategy;

internal static class StrategyUseCase
{
    public static string ResolveUsingPatternMatching(string selector, string[] @params)
      => new HashSet<IPattern<Error, StrategyContext, string>>
      {
            new FirstStrategy(),
            new SecondStrategy(),
            new ThirdStrategy(),

      }
      .Map(steps => StrategyContext
                    .With(selector)
                    .WithParams(@params)
                    .Map(context => MatchingPipeline<StrategyContext, string>
                                   .Given(context)
                                   .Match(steps, [], [])))
      .Match(_ => _.Result,
             _ => _.Message);

    public static Task<string> ResolveUsingAsyncPatternMatching(string selector, string[] @params)
      => new HashSet<IAsyncPattern<Error, StrategyContext, string>>
      {
            new AsyncFirstStrategy(),
            new AsyncSecondStrategy(),
            new AsyncThirdStrategy(),

      }
      .Map(steps => StrategyContext
                    .With(selector)
                    .WithParams(@params)
                    .Map(context => MatchingPipeline<StrategyContext, string>
                                   .Given(context)
                                   .Match(steps, [], [])))
      .MatchAsync(_ => _.Result,
                  _ => _.Message);

}

