using TinyFp;

namespace PipelineFp.Steps;

public interface IOnExceptionAsyncStep<TError, TContext>
{
    Task<Either<TError, TContext>> Forward(TContext context, Exception ex);
}
