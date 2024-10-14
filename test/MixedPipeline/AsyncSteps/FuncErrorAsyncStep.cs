using PipelineFpTest.DataTypes;
using TinyFp;


namespace PipelineFpTest.MixedPipeline.AsyncSteps;

internal static class FuncErrorAsyncStep
{
    internal static Func<MixedPipelineContext, Task<Either<Error, MixedPipelineContext>>> Error()
        => (context) => Either<Error, MixedPipelineContext>.Left(new Error
        {
            Message = "Error"
        }).AsTask();
}