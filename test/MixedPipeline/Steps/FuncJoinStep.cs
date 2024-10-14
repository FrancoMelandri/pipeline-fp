using PipelineFpTest.DataTypes;
using TinyFp;

namespace PipelineFpTest.MixedPipeline.Steps;

internal static class FuncJoinStep
{
    internal static Func<MixedPipelineContext, Either<Error, MixedPipelineContext>> Join()
        => (context) => Either<Error, MixedPipelineContext>.Right(context)
                        .Map(_ => _.WithResult(string.Format("Result is: {0}", context.Steps.Aggregate((state, current) => $"{state} {current}"))));
}