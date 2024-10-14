using PipelineFpTest.DataTypes;
using TinyFp;


namespace PipelineFpTest.MixedPipeline.AsyncSteps;

internal static class FuncExceptionHandlingAsyncStep
{
    internal static Func<MixedPipelineContext, Exception, Task<Either<Error, MixedPipelineContext>>> Handle()
        => (context, exception) => Either<Error, MixedPipelineContext>.Right(context)
                        .Map(_ => _.WithResult($"Exception was"))
                        .AsTask();
}