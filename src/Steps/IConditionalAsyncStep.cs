namespace PipelineFp.Steps;

public interface IConditionalAsyncStep<TError, TContext> : IAsyncStep<TError, TContext>
{
    Predicate<TContext> ExecutionCondition { get; }
}