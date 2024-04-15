using PipelineFp.Steps;
using TinyFp;

namespace PipelineFp.Pipelines;

public interface IPipeline<TContext>
{
    public Task<Either<TError, TContext>> Fit<TError>(
       IEnumerable<IAsyncStep<TError, TContext>> steps,
       IEnumerable<IOnErrorAsyncStep<TError, TContext>> onFailSteps,
       IEnumerable<IOnExceptionAsyncStep<TError, TContext>> onExceptionSteps);

    public Either<TError, TContext> Fit<TError>(
      IEnumerable<IStep<TError, TContext>> steps,
      IEnumerable<IOnErrorStep<TError, TContext>> onFailSteps,
      IEnumerable<IOnExceptionStep<TError, TContext>> onExceptionSteps);

    public Either<TError, TContext> Fit<TError>(IEnumerable<IStep<TError, TContext>> steps);

    public Task<Either<TError, TContext>> Fit<TError>(IEnumerable<IAsyncStep<TError, TContext>> steps);
}