using PipelineFpTest.Builder;

internal class SimpleBuilderStepsContext
{
    internal BuilderStep InputStep { get; }
    internal string[] Steps { get; }
    internal string Result { get; }

    private SimpleBuilderStepsContext(
        BuilderStep inputStep,
        string[] steps,
        string result)
    {
        InputStep = inputStep;
        Steps = steps;
        Result = result;
    }

    internal static SimpleBuilderStepsContext With(BuilderStep inputStep)
        => new(inputStep,
            [],
            string.Empty);

    internal SimpleBuilderStepsContext With(string[] steps)
        => new(InputStep,
            steps,
            Result);

    internal SimpleBuilderStepsContext With(string result)
        => new(InputStep,
            Steps,
            result);
}