using PipelineFpTest.DataTypes;
using TinyFp;

namespace PipelineFpTest.MixedPipeline.Steps;

internal static class FuncExceptionHandlingStep
{
    internal static Func<MixedPipelineContext, Exception, Either<Error, MixedPipelineContext>> Handle()
        => (context, exception) => Either<Error, MixedPipelineContext>.Right(context)
                        .Map(_ => _.WithResult($"Exception was"));
}