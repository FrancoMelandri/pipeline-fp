using TinyFp;

namespace PipelineFp.Extensions;

internal static class OptionExtensions
{
    internal static async Task<A> OrElse<A>(this Task<Option<A>> @this, Func<A> func)
        => (await @this).MapNone(func).Unwrap();

    internal static Task<A> OrElse<A>(this Task<Option<A>> @this, A val)
        => @this.OrElse(() => val);
}