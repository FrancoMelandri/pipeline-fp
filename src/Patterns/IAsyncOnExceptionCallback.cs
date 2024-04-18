using TinyFp;

namespace PipelineFp.Patterns;

public interface IAsyncOnExceptionCallback<TError, TContext>
{
    Task<Either<TError, TContext>> OnException(TContext context, Exception ex);
}
