namespace PipelineFp.Pipelines;

public interface IHashedStep<TContext, THash> : IBasicStep<TContext>
{
    THash Hash { get; }
}