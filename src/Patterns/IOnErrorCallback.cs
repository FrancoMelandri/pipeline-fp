using TinyFp;

public interface IOnErrorCallback<TError, TContext>
{
    Either<TError, TContext> OnError(TContext context, TError error);
}
