using PipelineFpTest.DataTypes;
using TinyFp;

namespace PipelineFpTest.MixedPipeline.AsyncSteps;

internal static class FuncJoinAsyncStep
{
    internal static Func<MixedPipelineContext, Task<Either<Error, MixedPipelineContext>>> Join()
        => (context) => Either<Error, MixedPipelineContext>.Right(context)
                        .Map(_ => _.WithResult(string.Format("Result is: {0}", context.Steps.Aggregate((state, current) => $"{state} {current}"))))
                        .AsTask();
}