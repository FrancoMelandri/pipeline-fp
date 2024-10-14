using PipelineFpTest.DataTypes;
using TinyFp;


namespace PipelineFpTest.MixedPipeline.AsyncSteps;

internal static class FuncErrorHandlingAsyncStep
{
    internal static Func<MixedPipelineContext, Error, Task<Either<Error, MixedPipelineContext>>> Handle()
        => (context, error) => Either<Error, MixedPipelineContext>.Right(context)
                        .Map(_ => _.WithResult($"Error was"))
                        .AsTask();
}
