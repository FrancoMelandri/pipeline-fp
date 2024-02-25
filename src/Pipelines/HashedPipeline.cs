using System.Collections.Immutable;
using TinyFp;
using TinyFp.Extensions;

namespace PipelineFp.Pipelines;

public static class HashedPipeline<TContext, TSelector>
    where TContext : IHashedContext<TSelector>
{
    public static Either<Unit, TContext> Evaluate(
        IEnumerable<IHashedStep<TContext, TSelector>> steps,
        TContext context)
        => steps
        .ToImmutableDictionary(step => step.Hash,
                                       step => step)
        .Map(_ => _.GetValueOrDefault(context.Selector))
        .Map(_ => _.Forward(context));
}