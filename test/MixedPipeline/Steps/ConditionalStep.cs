using PipelineFp.Steps;
using PipelineFpTest.DataTypes;
using TinyFp;

namespace PipelineFpTest.MixedPipeline.Steps;

internal class ConditionalStep : IConditionalStep<Error, MixedPipelineContext>
{
    public Predicate<MixedPipelineContext> ExecutionCondition => (context) => context.Input.Equals("ExecuteConditional");

    public Either<Error, MixedPipelineContext> Forward(MixedPipelineContext context)
        => Either<Error, MixedPipelineContext>.Right(context)
        .Map(UpdateContext);

    private static MixedPipelineContext UpdateContext(MixedPipelineContext context)
        => context.With(["Conditional"]);
}