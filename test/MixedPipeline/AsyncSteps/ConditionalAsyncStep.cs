using PipelineFp.Steps;
using PipelineFpTest.DataTypes;
using TinyFp;

namespace PipelineFpTest.MixedPipeline.AsyncSteps;

internal class ConditionalAsyncStep : IConditionalAsyncStep<Error, MixedPipelineContext>
{
    public Predicate<MixedPipelineContext> ExecutionCondition => (context) => context.Input.Equals("ExecuteConditional");

    public Task<Either<Error, MixedPipelineContext>> Forward(MixedPipelineContext context)
        => Either<Error, MixedPipelineContext>.Right(context)
        .Map(UpdateContext)
        .AsTask();

    private static MixedPipelineContext UpdateContext(MixedPipelineContext context)
        => context.With(["Conditional"]);
}