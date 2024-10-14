using PipelineFpTest.DataTypes;
using TinyFp;

namespace PipelineFpTest.MixedPipeline.Steps;

internal static class FuncExceptionStep
{
    internal static Func<MixedPipelineContext, Either<Error, MixedPipelineContext>> Exception()
        => (context) => throw new Exception("Exception");
}