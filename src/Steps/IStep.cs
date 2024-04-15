using TinyFp;

namespace PipelineFp.Steps;

public interface IStep<TError, TContext>
{
    Either<TError, TContext> Forward(TContext context);
}