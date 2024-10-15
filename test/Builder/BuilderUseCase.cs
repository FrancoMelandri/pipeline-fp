using PipelineFp.Pipelines;
using PipelineFpTest.Builder.AsyncPipeline;
using PipelineFpTest.Builder.Pipeline;
using PipelineFpTest.Switch;
using TinyFp;
using TinyFp.Extensions;

namespace PipelineFpTest.Builder;

public class BuilderUseCase
{
    public string ResolveUsingIf(BuilderStep switchStep)
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

    public static Task<string> ResolveUsingAsyncPipeline(BuilderStep initialValue)
        => BuilderAsyncStepsContext
        .With(initialValue)
        .Map(context => Pipeline<BuilderAsyncStepsContext>
                       .Given(context)
                       .Flow([
                           new BuilderAsyncFirstStep(),
                           new BuilderAsyncSecondStep(),
                           new BuilderAsyncThirdStep(),
                           new BuilderAsyncJoinStep()]))
        .MatchAsync(_ => _.Result,
                    _ => string.Empty);

    public static Task<string> ResolveUsingAsyncPipelineInCaseOfError(BuilderStep initialValue)
        => BuilderAsyncStepsContext
        .With(initialValue)
        .Map(context => Pipeline<BuilderAsyncStepsContext>
                       .Given(context)
                       .Flow([
                           new BuilderAsyncFirstStep(),
                           new BuilderAsyncSecondStep(),
                           new BuilderAsyncTestErrorStep(),
                           new BuilderAsyncThirdStep(),
                           new BuilderAsyncJoinStep()],
                           [new BuilderOnErrorAsyncStep()],
                           []))
        .MatchAsync(_ => _.Result,
                    _ => string.Empty);

    public static Task<string> ResolveUsingAsyncPipelineInCaseOfErrorWithoutErrorSteps(BuilderStep initialValue)
        => BuilderAsyncStepsContext
        .With(initialValue)
        .Map(context => Pipeline<BuilderAsyncStepsContext>
                       .Given(context)
                       .Flow([
                           new BuilderAsyncFirstStep(),
                           new BuilderAsyncSecondStep(),
                           new BuilderAsyncTestErrorStep(),
                           new BuilderAsyncThirdStep(),
                           new BuilderAsyncJoinStep()],
                           [],
                           []))
        .MatchAsync(_ => _.Result,
                    _ => _.Message);

    public static Task<string> ResolveUsingAsyncPipelineInCaseOfException(BuilderStep initialValue)
        => BuilderAsyncStepsContext
        .With(initialValue)
        .Map(context => Pipeline<BuilderAsyncStepsContext>
                       .Given(context)
                       .Flow([
                           new BuilderAsyncFirstStep(),
                           new BuilderAsyncSecondStep(),
                           new BuilderAsyncTestExceptionStep(),
                           new BuilderAsyncThirdStep(),
                           new BuilderAsyncJoinStep()],
                           [new BuilderOnErrorAsyncStep()],
                           [new BuilderOnExceptionAsyncStep()]))
        .MatchAsync(_ => _.Result,
                    _ => string.Empty);

    public static string ResolveUsingPipeline(BuilderStep initialValue)
       => BuilderStepsContext
       .With(initialValue)
       .Map(context => Pipeline<BuilderStepsContext>
                      .Given(context)
                      .Flow([
                          new BuilderFirstStep(),
                          new BuilderSecondStep(),
                          new BuilderThirdStep(),
                          new BuilderJoinStep()]))
       .Match(_ => _.Result,
              _ => string.Empty);

    public static string ResolveUsingPipelineInCaseOfError(BuilderStep initialValue)
        => BuilderStepsContext
        .With(initialValue)
        .Map(context => Pipeline<BuilderStepsContext>
                       .Given(context)
                       .Flow([
                           new BuilderFirstStep(),
                           new BuilderSecondStep(),
                           new BuilderTestErrorStep(),
                           new BuilderThirdStep(),
                           new BuilderJoinStep()],
                           [new BuilderOnErrorStep()],
                           []))
        .Match(_ => _.Result,
               _ => string.Empty);

    public static string ResolveUsingPipelineInCaseOfErrorWithoutErrorSteps(BuilderStep initialValue)
        => BuilderStepsContext
        .With(initialValue)
        .Map(context => Pipeline<BuilderStepsContext>
                       .Given(context)
                       .Flow([
                           new BuilderFirstStep(),
                           new BuilderSecondStep(),
                           new BuilderTestErrorStep(),
                           new BuilderThirdStep(),
                           new BuilderJoinStep()],
                           [],
                           []))
        .Match(_ => _.Result,
               _ => _.Message);

    public static string ResolveUsingPipelineInCaseOfException(BuilderStep initialValue)
        => BuilderStepsContext
        .With(initialValue)
        .Map(context => Pipeline<BuilderStepsContext>
                       .Given(context)
                       .Flow([
                           new BuilderFirstStep(),
                           new BuilderSecondStep(),
                           new BuilderTestExceptionStep(),
                           new BuilderThirdStep(),
                           new BuilderJoinStep()],
                           [new BuilderOnErrorStep()],
                           [new BuilderOnExceptionStep()]))
        .Match(_ => _.Result,
               _ => string.Empty);
}