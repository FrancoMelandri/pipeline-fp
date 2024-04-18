using PipelineFpTest.DataTypes;
using TinyFp;

namespace PipelineFpTest.Switch.MatchingPipeline;

internal class SwitchOnError : IOnErrorCallback<Error, SwitchPatternContext>
{
    public Either<Error, SwitchPatternContext> OnError(SwitchPatternContext context, Error error)
        => context.With("Error");
}
