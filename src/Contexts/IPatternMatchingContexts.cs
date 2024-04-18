namespace PipelineFp.Contexts;

public interface IPatternMatchingContext<out TSelector>
{
    TSelector Selector { get; }
}