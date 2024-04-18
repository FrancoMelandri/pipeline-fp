using PipelineFpTest.DataTypes;
using TinyFp;
using TinyFp.Extensions;

namespace PipelineFpTest.Strategy.MatchingPipeline;
internal class FirstStrategy : IPattern<Error, StrategyContext, string>
{
    public string Selector => "first";

    public Either<Error, StrategyContext> Match(StrategyContext context)
        => TinyFp.Prelude.Try(() => context.Params[0]
                                   .Map(context.WithResult)
                                   .Map(TinyFp.Prelude.Right<Error, StrategyContext>))
        .OnFail(new Error { Message = "First strategy error" });
}

