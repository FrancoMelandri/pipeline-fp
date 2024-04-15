using PipelineFpTest.DataTypes;
using TinyFp;
using TinyFp.Extensions;

namespace PipelineFpTest.Strategy.MatchingPipeline;

internal class SecondStrategy : IPattern<Error, StrategyContext, string>
{
    public string Selector => "second";

    public Either<Error, StrategyContext> Match(StrategyContext context)
        => TinyFp.Prelude.Try(() => context.Params[1]
                                   .Map(context.WithResult)
                                   .Map(TinyFp.Prelude.Right<Error, StrategyContext>))
        .OnFail(new Error { Message = "Second strategy error" });
}

