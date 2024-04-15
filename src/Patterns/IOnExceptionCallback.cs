using TinyFp;

public interface IOnExceptionCallback<TError, TContext>
{
    Either<TError, TContext> OnException(TContext context, Exception ex);
}
