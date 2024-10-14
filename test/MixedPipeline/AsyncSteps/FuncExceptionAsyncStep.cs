using PipelineFpTest.DataTypes;
using TinyFp;

namespace PipelineFpTest.MixedPipeline.AsyncSteps;

internal static class FuncExceptionAsyncStep
{
    internal static Func<MixedPipelineContext, Task<Either<Error, MixedPipelineContext>>> Exception()
        => (context) => throw new Exception("Exception");
}