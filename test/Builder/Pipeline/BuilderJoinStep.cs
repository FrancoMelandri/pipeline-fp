using PipelineFp.Steps;
using PipelineFpTest.DataTypes;
using TinyFp;
using TinyFp.Extensions;
using static PipelineFpTest.Builder.Constants.Steps;

namespace PipelineFpTest.Builder.Pipeline;

internal class BuilderJoinStep : IStep<Error, BuilderStepsContext>
{
    public Either<Error, BuilderStepsContext> Forward(BuilderStepsContext context)
        => Either<Error, BuilderStepsContext>.Right(context)
        .Map(UpdateContext);

    private static BuilderStepsContext UpdateContext(BuilderStepsContext context)
        => context
        .ToOption()
        .Map(_ => _.With(string.Join(Joiner, _.Steps)))
        .OrElse(context);
}
