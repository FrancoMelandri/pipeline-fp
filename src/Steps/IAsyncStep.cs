using TinyFp;

namespace PipelineFp.Steps;

public interface IAsyncStep<TError, TContext>
{
    Task<Either<TError, TContext>> Forward(TContext context);
}