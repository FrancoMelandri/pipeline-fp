using TinyFp;

namespace PipelineFp.Steps;

public interface IOnErrorAsyncStep<TError, TContext>
{
    Task<Either<TError, TContext>> Forward(TContext context, TError error);
}
