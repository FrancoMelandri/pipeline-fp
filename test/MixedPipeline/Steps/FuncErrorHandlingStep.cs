using PipelineFpTest.DataTypes;
using TinyFp;

namespace PipelineFpTest.MixedPipeline.Steps;

internal static class FuncErrorHandlingStep
{
    internal static Func<MixedPipelineContext, Error, Either<Error, MixedPipelineContext>> Handle()
        => (context, error) => Either<Error, MixedPipelineContext>
                               .Right(context)
                               .Map(_ => _.WithResult($"Error was"));
}