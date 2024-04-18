using PipelineFpTest.Switch;
using TinyFp.Extensions;

namespace PipelineFpTest.Builder.Pipeline;

internal class BuilderStepsContext
{
    internal BuilderStep InputStep { get; private set; }
    internal string[] Steps { get; private set; }
    internal string Result { get; private set; }

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
        => this.Tee(_ => _.Steps = [.. Steps, .. steps]);

    internal BuilderStepsContext With(string result)
        => this.Tee(_ => _.Result = result);
}
