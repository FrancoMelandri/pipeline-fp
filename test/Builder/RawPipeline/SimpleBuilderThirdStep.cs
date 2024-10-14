using PipelineFp.Steps;
using PipelineFpTest.Builder;
using PipelineFpTest.DataTypes;
using TinyFp;
using TinyFp.Extensions;
using static PipelineFpTest.Builder.Constants.Steps;

namespace CriFp.Pipeline.Tests.Builder.RawPipeline;

internal class SimpleBuilderThirdStep : IStep<Error, SimpleBuilderStepsContext>
{
    public Either<Error, SimpleBuilderStepsContext> Forward(SimpleBuilderStepsContext context)
        => Either<Error, SimpleBuilderStepsContext>.Right(context)
        .Map(UpdateContext);

    private static SimpleBuilderStepsContext UpdateContext(SimpleBuilderStepsContext context)
        => context
        .ToOption(_ => !_.InputStep.HasFlag(BuilderStep.Third))
        .Map(_ => _.With([.. _.Steps, Third]))
        .OrElse(context);
}