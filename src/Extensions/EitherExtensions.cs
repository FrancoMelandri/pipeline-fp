using TinyFp;

namespace PipelineFp.Extensions;

internal static class EitherExtensions
{
    public static async Task<Either<M, R>> BindLeftAsync<L, R, M>(this Task<Either<L, R>> @this, Func<L, Task<Either<M, R>>> onLeft)
    {
        return await (await @this).BindLeftAsync(onLeft);
    }
}