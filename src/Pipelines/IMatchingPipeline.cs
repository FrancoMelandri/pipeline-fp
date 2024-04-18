using PipelineFp.Contexts;
using PipelineFp.Patterns;
using TinyFp;

namespace PipelineFp.Pipelines;

public interface IMatchingPipeline<TContext, TSelector> where TContext : IPatternMatchingContext<TSelector>
{
    public Either<TError, TContext> Match<TError>(HashSet<IPattern<TError, TContext, TSelector>> patterns);

    public Task<Either<TError, TContext>> Match<TError>(HashSet<IAsyncPattern<TError, TContext, TSelector>> patterns);

    public Task<Either<TError, TContext>> Match<TError>(
        HashSet<IAsyncPattern<TError, TContext, TSelector>> patterns,
        HashSet<IAsyncOnErrorCallback<TError, TContext>> onErrorCallbacks,
        HashSet<IAsyncOnExceptionCallback<TError, TContext>> onExceptionCallbacks);

    public Either<TError, TContext> Match<TError>(
        HashSet<IPattern<TError, TContext, TSelector>> patterns,
        HashSet<IOnErrorCallback<TError, TContext>> onErrorCallbacks,
        HashSet<IOnExceptionCallback<TError, TContext>> onExceptionCallbacks);
}