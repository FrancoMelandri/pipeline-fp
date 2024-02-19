using PipelineFpTest.Switch;

namespace PipelineFpTest.Builder;

public class BuilderUseCase
{
    public string ResolveUsingIf(BuilderStep switchStep)
    {
        string[] steps = [];
        if (switchStep.HasFlag(BuilderStep.First))
            steps = steps.Append("First").ToArray();
        if (switchStep.HasFlag(BuilderStep.Second))
            steps = steps.Append("Second").ToArray();
        if (switchStep.HasFlag(BuilderStep.Third))
            steps = steps.Append("Third").ToArray();
        return string.Join(",", steps);
    }
}