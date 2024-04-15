using PipelineFp.Steps;
using PipelineFpTest.DataTypes;
using TinyFp;
using TinyFp.Extensions;
using static PipelineFpTest.Builder.Constants.Steps;

namespace PipelineFpTest.Builder.AsyncPipeline;

internal class BuilderAsyncJoinStep : IAsyncStep<Error, BuilderAsyncStepsContext>
{
    public Task<Either<Error, BuilderAsyncStepsContext>> Forward(BuilderAsyncStepsContext context)
        => Either<Error, BuilderAsyncStepsContext>.Right(context)
        .MapAsync(UpdateContext);

    private static Task<BuilderAsyncStepsContext> UpdateContext(BuilderAsyncStepsContext context)
        => context
        .ToOption()
        .Map(_ => _.With(string.Join(Joiner, _.Steps)))
        .OrElse(context)
        .AsTask();
}

