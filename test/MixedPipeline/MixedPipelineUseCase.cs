using PipelineFp.Pipelines;
using PipelineFpTest.DataTypes;
using PipelineFpTest.MixedPipeline.AsyncSteps;
using PipelineFpTest.MixedPipeline.Steps;
using TinyFp;
using TinyFp.Extensions;

namespace PipelineFpTest.MixedPipeline;

internal static class MixedPipelineUseCase
{
    internal static Task<string> ResolveUsingMixedAsyncPipeline(string executeConditional)
        => MixedPipelineContext
        .With(executeConditional)
        .Map(context => Pipeline<MixedPipelineContext>
                        .Given(context)
                        .Flow<Error>([new SimpleAsyncStep(),
                                     new ConditionalAsyncStep(),
                                     FuncJoinAsyncStep.Join()]))
        .MatchAsync(_ => _.Result,
                    _ => string.Empty);
    
    internal static Task<string> ResolveUsingMixedAsyncPipelineWhenError(string executeConditional)
       => MixedPipelineContext
       .With(executeConditional)
       .Map(context => Pipeline<MixedPipelineContext>
                       .Given(context)
                       .Flow<Error>([new SimpleAsyncStep(),
                                    new ConditionalAsyncStep(),
                                    FuncJoinAsyncStep.Join(),
                                    FuncErrorAsyncStep.Error()],
                                   [FuncErrorHandlingAsyncStep.Handle(),
                                    new ErrorHandlingAsyncStep()],
                                   []))
       .MatchAsync(_ => _.Result,
                   _ => string.Empty);

    internal static Task<string> ResolveUsingMixedAsyncPipelineWhenException(string executeConditional)
       => MixedPipelineContext
       .With(executeConditional)
       .Map(context => Pipeline<MixedPipelineContext>
                       .Given(context)
                       .Flow<Error>([new SimpleAsyncStep(),
                                    new ConditionalAsyncStep(),
                                    FuncJoinAsyncStep.Join(),
                                    FuncExceptionAsyncStep.Exception()],
                                   [FuncErrorHandlingAsyncStep.Handle(),
                                    new ErrorHandlingAsyncStep()],
                                   [FuncExceptionHandlingAsyncStep.Handle(),
                                    new ExceptionHandlingAsyncStep()]))
       .MatchAsync(_ => _.Result,
                   _ => string.Empty);

    internal static string ResolveUsingMixedPipelineWhenError(string executeConditional)
       => MixedPipelineContext
       .With(executeConditional)
       .Map(context => Pipeline<MixedPipelineContext>
                       .Given(context)
                       .Flow<Error>([new SimpleStep(),
                                    new ConditionalStep(),
                                    FuncJoinStep.Join(),
                                    FuncErrorStep.Error()],
                                   [FuncErrorHandlingStep.Handle(),
                                    new ErrorHandlingStep()],
                                   []))
       .Match(_ => _.Result,
              _ => string.Empty);

    internal static string ResolveUsingMixedPipelineWhenException(string executeConditional)
       => MixedPipelineContext
       .With(executeConditional)
       .Map(context => Pipeline<MixedPipelineContext>
                       .Given(context)
                       .Flow<Error>([new SimpleStep(),
                                    new ConditionalStep(),
                                    FuncJoinStep.Join(),
                                    FuncExceptionStep.Exception()],
                                   [FuncErrorHandlingStep.Handle(),
                                    new ErrorHandlingStep()],
                                   [FuncExceptionHandlingStep.Handle(),
                                    new ExceptionHandlingStep()]))
       .Match(_ => _.Result,
              _ => string.Empty);

    internal static string ResolveUsingMixedPipeline(string executeConditional)
        => MixedPipelineContext
        .With(executeConditional)
        .Map(context => Pipeline<MixedPipelineContext>
                        .Given(context)
                        .Flow<Error>([new SimpleStep(),
                                     new ConditionalStep(),
                                     FuncJoinStep.Join()]))
        .Match(_ => _.Result,
                    _ => string.Empty);
}