using PipelineFpTest.DataTypes;
using TinyFp;

namespace PipelineFpTest.Switch.MatchingPipeline;

internal class SwitchOnException : IOnExceptionCallback<Error, SwitchPatternContext>
{
    public Either<Error, SwitchPatternContext> OnException(SwitchPatternContext context, Exception ex)
        => context.With(ex.Message);
}
