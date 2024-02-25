using TinyFp;

namespace PipelineFp.Pipelines;

public interface IStep<TContext>
{
    Either<Unit, TContext> Forward(TContext context);
}