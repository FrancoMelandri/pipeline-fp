using CriFp.Pipeline.Tests.Builder.RawPipeline;
using PipelineFp.Steps;
using PipelineFpTest.DataTypes;
using TinyFp;
using TinyFp.Extensions;
using static PipelineFpTest.Builder.Constants.Steps;

namespace CriFp.Pipeline.Tests.Builder.RawPipeline;

internal class SimpleBuilderJoinStep : IStep<Error, SimpleBuilderStepsContext>
{
    public Either<Error, SimpleBuilderStepsContext> Forward(SimpleBuilderStepsContext context)
        => Either<Error, SimpleBuilderStepsContext>.Right(context)
        .Map(UpdateContext);

    private static SimpleBuilderStepsContext UpdateContext(SimpleBuilderStepsContext context)
        => context
        .ToOption()
        .Map(_ => _.With(string.Join(Joiner, _.Steps)))
        .OrElse(context);
}