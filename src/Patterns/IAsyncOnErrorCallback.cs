using TinyFp;

namespace PipelineFp.Patterns;

public interface IAsyncOnErrorCallback<TError, TContext>
{
    Task<Either<TError, TContext>> OnError(TContext context, TError error);
}