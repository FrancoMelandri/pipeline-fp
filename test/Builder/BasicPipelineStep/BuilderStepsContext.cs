using PipelineFpTest.Switch;

namespace PipelineFpTest.Builder.BasicPipelineStep;

internal class BuilderStepsContext
{
    internal BuilderStep InputStep { get; }
    internal string[] Steps { get; }
    internal string Result { get; }

    private BuilderStepsContext(
        BuilderStep inputStep,
        string[] steps,
        string result)
    {
        InputStep = inputStep;
        Steps = steps;
        Result = result;
    }

    internal static BuilderStepsContext With(BuilderStep inputStep)
        => new(inputStep,
            [],
            string.Empty);

    internal BuilderStepsContext With(string[] steps)
        => new(InputStep,
            steps,
            Result);

    internal BuilderStepsContext With(string result)
        => new(InputStep,
            Steps,
            result);
}