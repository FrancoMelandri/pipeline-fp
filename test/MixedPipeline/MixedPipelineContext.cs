namespace PipelineFpTest.MixedPipeline;

internal class MixedPipelineContext
{
    internal string Input { get; private set; }
    internal string[] Steps { get; private set; }
    internal string Result { get; private set; }

    private MixedPipelineContext(
        string input,
        string[] steps,
        string result)
    {
        Input = input;
        Steps = steps;
        Result = result;
    }

    internal static MixedPipelineContext With(string input)
        => new(input,
            [],
            string.Empty);

    internal MixedPipelineContext With(string[] steps)
        => new(Input,
               [.. Steps, .. steps],
               Result);

    internal MixedPipelineContext WithResult(string result)
        => new(Input,
               Steps,
               result);
}