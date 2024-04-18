using TinyFp;

public interface IPattern<TError, TContext, out TSelector>
{
    Either<TError, TContext> Match(TContext context);
    TSelector Selector { get; }
}