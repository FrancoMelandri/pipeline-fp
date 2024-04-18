using PipelineFp.Steps;
using PipelineFpTest.DataTypes;
using TinyFp;
using TinyFp.Extensions;
using static PipelineFpTest.Builder.Constants.Steps;

namespace PipelineFpTest.Builder.AsyncPipeline;

internal class BuilderOnErrorAsyncStep : IOnErrorAsyncStep<Error, BuilderAsyncStepsContext>
{
    public Task<Either<Error, BuilderAsyncStepsContext>> Forward(BuilderAsyncStepsContext context, Error error)
        => context.With($"Error Handled: {error.Message}. Executed steps: {string.Join(Joiner, context.Steps)}")
        .Map(Either<Error, BuilderAsyncStepsContext>.Right)
        .AsTask();
}

