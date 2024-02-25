using PipelineFp.Pipelines;
using PipelineFpTest.Builder.BasicPipelineStep;
using PipelineFpTest.Switch;
using TinyFp.Extensions;

namespace PipelineFpTest.Builder;

public static class BuilderUseCase
{
    public static string ResolveUsingIf(BuilderStep switchStep)
    {
        string[] steps = [];
        if (switchStep.HasFlag(BuilderStep.First))
            steps = [.. steps, "First"];
        if (switchStep.HasFlag(BuilderStep.Second))
            steps = [.. steps, "Second"];
        if (switchStep.HasFlag(BuilderStep.Third))
            steps = [.. steps, "Third"];
        return string.Join(",", steps);
    }

    public static string ResolveUsingBasicPipeline(BuilderStep basicPipelineSteps)
        => new List<IStep<BuilderStepsContext>>
        {
            new BuilderFirstStep(),
            new BuilderSecondStep(),
            new BuilderThirdStep(),
            new BuilderJoinStep(),
        }
        .Map(steps => BuilderStepsContext
                      .With(basicPipelineSteps)
                      .Map(context => BasicPipeline<BuilderStepsContext>
                                      .Evaluate(steps, context)))
        .Match(_ => _.Result,
               _ => string.Empty);
}