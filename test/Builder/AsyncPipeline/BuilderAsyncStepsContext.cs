using PipelineFpTest.Switch;
using TinyFp.Extensions;

namespace PipelineFpTest.Builder.AsyncPipeline;

internal class BuilderAsyncStepsContext
{
    internal BuilderStep InputStep { get; private set; }
    internal string[] Steps { get; private set; }
    internal string Result { get; private set; }

    private BuilderAsyncStepsContext(
        BuilderStep inputStep,
        string[] steps,
        string result)
    {
        InputStep = inputStep;
        Steps = steps;
        Result = result;
    }

    internal static BuilderAsyncStepsContext With(BuilderStep inputStep)
        => new(inputStep,
            [],
            string.Empty);

    internal BuilderAsyncStepsContext With(string[] steps)
        => this.Tee(_ => _.Steps = [.. Steps, .. steps]);

    internal BuilderAsyncStepsContext With(string result)
        => this.Tee(_ => _.Result = result);
}

