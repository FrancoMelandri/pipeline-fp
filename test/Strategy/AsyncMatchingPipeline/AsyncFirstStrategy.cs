using PipelineFp.Patterns;
using PipelineFpTest.DataTypes;
using TinyFp;
using TinyFp.Extensions;

namespace PipelineFpTest.Strategy.AsyncMatchingPipeline;

internal class AsyncFirstStrategy : IAsyncPattern<Error, StrategyContext, string>
{
    public string Selector => "first";

    public Task<Either<Error, StrategyContext>> Match(StrategyContext context)
        => TinyFp.Prelude.TryAsync(() => context.Params[0]
                                   .Map(context.WithResult)
                                   .Map(TinyFp.Prelude.Right<Error, StrategyContext>)
                                   .AsTask())
        .OnFail(new Error { Message = "First strategy error" });
}