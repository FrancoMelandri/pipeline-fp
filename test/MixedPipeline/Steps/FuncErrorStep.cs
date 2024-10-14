using PipelineFpTest.DataTypes;
using TinyFp;

namespace PipelineFpTest.MixedPipeline.Steps;

internal static class FuncErrorStep
{
    internal static Func<MixedPipelineContext, Either<Error, MixedPipelineContext>> Error()
        => (context) => Either<Error, MixedPipelineContext>.Left(new Error
        {
            Message = "Error"
        });
}