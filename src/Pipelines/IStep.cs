using TinyFp;

namespace PipelineFp.Pipelines;

public interface IBasicStep<TContext>
{
    Either<Unit, TContext> Forward(TContext context);
}

public interface IConditionalStep<TContext>
{
    Predicate<TContext> ExecutionCondition { get; }
    Either<Unit, TContext> Forward(TContext context);
}