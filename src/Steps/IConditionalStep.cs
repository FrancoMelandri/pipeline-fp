namespace PipelineFp.Steps;

public interface IConditionalStep<TError, TContext> : IStep<TError, TContext>
{
    Predicate<TContext> ExecutionCondition { get; }
}