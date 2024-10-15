using PipelineFp.Steps;
using TinyFp;

namespace PipelineFp.Pipelines;

public interface IPipeline<TContext>
{
    public Task<Either<TError, TContext>> Flow<TError>(
       IEnumerable<IAsyncStep<TError, TContext>> steps,
       IEnumerable<IOnErrorAsyncStep<TError, TContext>> onFailSteps,
       IEnumerable<IOnExceptionAsyncStep<TError, TContext>> onExceptionSteps);

    public Either<TError, TContext> Flow<TError>(
      IEnumerable<IStep<TError, TContext>> steps,
      IEnumerable<IOnErrorStep<TError, TContext>> onFailSteps,
      IEnumerable<IOnExceptionStep<TError, TContext>> onExceptionSteps);

    public Task<Either<TError, TContext>> Flow<TError>(
        IEnumerable<Union<Func<TContext, Task<Either<TError, TContext>>>,
                    IConditionalAsyncStep<TError, TContext>,
                    IAsyncStep<TError, TContext>>> steps);

    public Task<Either<TError, TContext>> Flow<TError>(
       IEnumerable<Union<Func<TContext, Task<Either<TError, TContext>>>,
                   IConditionalAsyncStep<TError, TContext>,
                   IAsyncStep<TError, TContext>>> steps,
       IEnumerable<Union<Func<TContext, TError, Task<Either<TError, TContext>>>,
                         IOnErrorAsyncStep<TError, TContext>>> onFailSteps,
       IEnumerable<Union<Func<TContext, Exception, Task<Either<TError, TContext>>>,
                         IOnExceptionAsyncStep<TError, TContext>>> onExceptionSteps);

    public Either<TError, TContext> Flow<TError>(
        IEnumerable<Union<Func<TContext, Either<TError, TContext>>,
                    IConditionalStep<TError, TContext>,
                    IStep<TError, TContext>>> steps);

    public Either<TError, TContext> Flow<TError>(
       IEnumerable<Union<Func<TContext, Either<TError, TContext>>,
                   IConditionalStep<TError, TContext>,
                   IStep<TError, TContext>>> steps,
       IEnumerable<Union<Func<TContext, TError, Either<TError, TContext>>,
                         IOnErrorStep<TError, TContext>>> onFailSteps,
       IEnumerable<Union<Func<TContext, Exception, Either<TError, TContext>>,
                         IOnExceptionStep<TError, TContext>>> onExceptionSteps);

    public Either<TError, TContext> Flow<TError>(IEnumerable<IStep<TError, TContext>> steps);

    public Task<Either<TError, TContext>> Flow<TError>(IEnumerable<IAsyncStep<TError, TContext>> steps);
}