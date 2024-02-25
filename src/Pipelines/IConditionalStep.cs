namespace PipelineFp.Pipelines;

public interface IConditionalStep<TContext> : IBasicStep<TContext>
{
    Predicate<TContext> ExecutionCondition { get; }
}