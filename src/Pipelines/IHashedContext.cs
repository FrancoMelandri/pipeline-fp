namespace PipelineFp.Pipelines;

public interface IHashedContext<TSelector>
{
    TSelector Selector { get; }
}