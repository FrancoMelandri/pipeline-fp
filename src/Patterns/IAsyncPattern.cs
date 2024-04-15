using TinyFp;

namespace PipelineFp.Patterns;

public interface IAsyncPattern<TError, TContext, out TSelector>
{
    Task<Either<TError, TContext>> Match(TContext context);
    TSelector Selector { get; }
}
