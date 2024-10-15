using PipelineFp.Steps;
using TinyFp;

namespace PipelineFp.Pipelines;

public interface IConditionalPipeline<TContext>
{
    public Task<Either<TError, TContext>> Flow<TError>(
       IEnumerable<IConditionalAsyncStep<TError, TContext>> steps,
       IEnumerable<IOnErrorAsyncStep<TError, TContext>> onFailSteps,
       IEnumerable<IOnExceptionAsyncStep<TError, TContext>> onExceptionSteps);

    public Either<TError, TContext> Flow<TError>(
      IEnumerable<IConditionalStep<TError, TContext>> steps,
      IEnumerable<IOnErrorStep<TError, TContext>> onFailSteps,
      IEnumerable<IOnExceptionStep<TError, TContext>> onExceptionSteps);

    public Either<TError, TContext> Flow<TError>(IEnumerable<IConditionalStep<TError, TContext>> steps);

    public Task<Either<TError, TContext>> Flow<TError>(IEnumerable<IConditionalAsyncStep<TError, TContext>> steps);
}


