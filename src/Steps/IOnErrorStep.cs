using TinyFp;

namespace PipelineFp.Steps;

public interface IOnErrorStep<TError, TContext>
{
    Either<TError, TContext> Forward(TContext context, TError error);
}
