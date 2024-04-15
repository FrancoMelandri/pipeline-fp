using PipelineFp.Steps;
using PipelineFpTest.DataTypes;
using TinyFp;
using static PipelineFpTest.Builder.Constants.Steps;

namespace PipelineFpTest.Builder.AsyncPipeline;

internal class BuilderOnExceptionAsyncStep : IOnExceptionAsyncStep<Error, BuilderAsyncStepsContext>
{
    public Task<Either<Error, BuilderAsyncStepsContext>> Forward(BuilderAsyncStepsContext context, Exception ex)
       => Either<Error, BuilderAsyncStepsContext>.Right(context)
       .MapAsync(_ => UpdateContext(_, ex));

    private static Task<BuilderAsyncStepsContext> UpdateContext(BuilderAsyncStepsContext context, Exception ex)
    => context.With($"Exception Handled: {ex.Message}. Executed steps: {string.Join(Joiner, context.Steps)}")
        .AsTask();
}

