using CriFp.Pipeline.Tests.Builder.RawPipeline;
using PipelineFp.Steps;
using PipelineFpTest.DataTypes;
using TinyFp;
using TinyFp.Extensions;
using static PipelineFpTest.Builder.Constants.Steps;

namespace PipelineFpTest.Builder.RawPipeline;

internal class SimpleBuilderFirstStep : IStep<Error, SimpleBuilderStepsContext>
{
    public Either<Error, SimpleBuilderStepsContext> Forward(SimpleBuilderStepsContext context)
        => Either<Error, SimpleBuilderStepsContext>.Right(context)
        .Map(UpdateContext);

    private static SimpleBuilderStepsContext UpdateContext(SimpleBuilderStepsContext context)
        => context
        .ToOption(_ => !_.InputStep.HasFlag(BuilderStep.First))
        .Map(_ => _.With([.. _.Steps, First]))
        .OrElse(context);
}