using PipelineFpTest.DataTypes;
using TinyFp;
using TinyFp.Extensions;

namespace PipelineFpTest.Strategy.MatchingPipeline;

internal class ThirdStrategy : IPattern<Error, StrategyContext, string>
{
    public string Selector => "third";

    public Either<Error, StrategyContext> Match(StrategyContext context)
        => TinyFp.Prelude.Try(() => context.Params[2]
                                   .Map(context.WithResult)
                                   .Map(TinyFp.Prelude.Right<Error, StrategyContext>))
        .OnFail(new Error { Message = "Third strategy error" });
}

