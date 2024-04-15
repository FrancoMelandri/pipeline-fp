using TinyFp;

namespace PipelineFp.Steps;

public interface IOnExceptionStep<TError, TContext>
{
    Either<TError, TContext> Forward(TContext context, Exception ex);
}
