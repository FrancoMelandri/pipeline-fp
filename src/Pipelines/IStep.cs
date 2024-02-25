using TinyFp;

namespace PipelineFp.Pipelines;

public interface IBasicStep<TContext>
{
    Either<Unit, TContext> Forward(TContext context);
}