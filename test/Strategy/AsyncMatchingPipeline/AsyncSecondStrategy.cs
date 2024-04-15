using PipelineFp.Patterns;
using PipelineFpTest.DataTypes;
using TinyFp;
using TinyFp.Extensions;

namespace PipelineFpTest.Strategy.AsyncMatchingPipeline;

internal class AsyncSecondStrategy : IAsyncPattern<Error, StrategyContext, string>
{
    public string Selector => "second";

    public Task<Either<Error, StrategyContext>> Match(StrategyContext context)
        => TinyFp.Prelude.TryAsync(() => context.Params[1]
                                   .Map(context.WithResult)
                                   .Map(TinyFp.Prelude.Right<Error, StrategyContext>)
                                   .AsTask())
        .OnFail(new Error { Message = "Second strategy error" });
}

