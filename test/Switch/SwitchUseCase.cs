using PipelineFp.Patterns;
using PipelineFp.Pipelines;
using PipelineFp.Steps;
using PipelineFpTest.DataTypes;
using PipelineFpTest.Switch.AsyncMatchingPipeline;
using PipelineFpTest.Switch.ConditionalAsyncPipeline;
using PipelineFpTest.Switch.ConditionalPipeline;
using PipelineFpTest.Switch.MatchingPipeline;
using TinyFp;
using TinyFp.Extensions;

namespace PipelineFpTest.Switch;

public class SwitchUseCase
{
    public string ResolveUsingSwitch(SwitchSelector switchSelector)
        => switchSelector switch
        {
            SwitchSelector.None => "None selector",
            SwitchSelector.North => "North selector",
            SwitchSelector.South => "South selector",
            SwitchSelector.West => "West selector",
            SwitchSelector.East => "Est selector"
        };


    public static string ResolveUsingConditionalPipeline(SwitchSelector switchSelector)
        => new List<IConditionalStep<Error, SwitchContext>>
        {
            new SwitchNoneConditionalStep(),
            new SwitchNorthConditionalStep(),
            new SwitchEastConditionalStep(),
            new SwitchSouthConditionalStep(),
            new SwitchWestConditionalStep(),
        }
        .Map(steps => SwitchContext
                      .With(switchSelector)
                      .Map(context => ConditionalPipeline<SwitchContext>
                                      .Given(context)
                                      .Flow(steps)))
        .Match(_ => _.Result,
               _ => string.Empty);

    public static Task<string> ResolveUsingConditionalAsyncPipeline(SwitchSelector switchSelector)
        => new List<IConditionalAsyncStep<Error, SwitchContext>>
        {
            new SwitchNoneConditionalAsyncStep(),
            new SwitchNorthConditionalAsyncStep(),
            new SwitchEastConditionalAsyncStep(),
            new SwitchSouthConditionalAsyncStep(),
            new SwitchWestConditionalAsyncStep(),
        }
        .Map(steps => SwitchContext
                      .With(switchSelector)
                      .Map(context => ConditionalPipeline<SwitchContext>
                                      .Given(context)
                                      .Flow(steps)))
        .MatchAsync(_ => _.Result,
               _ => string.Empty);

    public static Task<string> ResolveUsingConditionalAsyncPipeline_WhenError(SwitchSelector switchSelector)
        => new List<IConditionalAsyncStep<Error, SwitchContext>>
        {
            new SwitchNoneConditionalAsyncStep(),
            new SwitchErrorConditionalAsyncStep(),
            new SwitchNorthConditionalAsyncStep(),
            new SwitchEastConditionalAsyncStep(),
            new SwitchSouthConditionalAsyncStep(),
            new SwitchWestConditionalAsyncStep(),
        }
        .Map(steps => SwitchContext
                      .With(switchSelector)
                      .Map(context => ConditionalPipeline<SwitchContext>
                                      .Given(context)
                                      .Flow(steps, [new SwitchOnErrorAsyncStep()], [])))
        .MatchAsync(_ => _.Result,
               _ => string.Empty);

    public static Task<string> ResolveUsingConditionalAsyncPipeline_WhenErrorAndWithoutErrorSteps(SwitchSelector switchSelector)
        => new List<IConditionalAsyncStep<Error, SwitchContext>>
        {
            new SwitchNoneConditionalAsyncStep(),
            new SwitchErrorConditionalAsyncStep(),
            new SwitchNorthConditionalAsyncStep(),
            new SwitchEastConditionalAsyncStep(),
            new SwitchSouthConditionalAsyncStep(),
            new SwitchWestConditionalAsyncStep(),
        }
        .Map(steps => SwitchContext
                      .With(switchSelector)
                      .Map(context => ConditionalPipeline<SwitchContext>
                                      .Given(context)
                                      .Flow(steps, [], [])))
        .MatchAsync(_ => _.Result,
                    _ => _.Message);

    public static Task<string> ResolveUsingConditionalAsyncPipeline_WhenException(SwitchSelector switchSelector)
        => new List<IConditionalAsyncStep<Error, SwitchContext>>
        {
            new SwitchNoneConditionalAsyncStep(),
            new SwitchExceptionConditionalAsyncStep(),
            new SwitchNorthConditionalAsyncStep(),
            new SwitchEastConditionalAsyncStep(),
            new SwitchSouthConditionalAsyncStep(),
            new SwitchWestConditionalAsyncStep(),
        }
        .Map(steps => SwitchContext
                      .With(switchSelector)
                      .Map(context => ConditionalPipeline<SwitchContext>
                                      .Given(context)
                                      .Flow(steps, [new SwitchOnErrorAsyncStep()], [new SwitchOnExceptionAsyncStep()])))
        .MatchAsync(_ => _.Result,
               _ => string.Empty);

    public static string ResolveUsingPatternMatching(SwitchSelector switchSelector)
        => new HashSet<IPattern<Error, SwitchPatternContext, SwitchSelector>>
        {
            new SwitchNonePattern(),
            new SwitchNorthPattern(),
            new SwitchSouthPattern(),
            new SwitchEastPattern(),
            new SwitchWestPattern(),
            new SwitchErrorPattern(),
            new SwitchExceptionPattern()
        }
        .Map(steps => SwitchPatternContext
                      .With(switchSelector)
                      .Map(context => MatchingPipeline<SwitchPatternContext, SwitchSelector>
                                     .Given(context)
                                     .Match(steps, [new SwitchOnError()], [new SwitchOnException()])))
        .Match(_ => _.Result,
               _ => string.Empty);

    public static Task<string> ResolveUsingAsyncPatternMatching(SwitchSelector switchSelector)
        => new HashSet<IAsyncPattern<Error, SwitchPatternAsyncContext, SwitchSelector>>
        {
            new SwitchNoneAsyncPattern(),
            new SwitchNorthAsyncPattern(),
            new SwitchSouthAsyncPattern(),
            new SwitchEastAsyncPattern(),
            new SwitchWestAsyncPattern(),
            new SwitchErrorAsyncPattern(),
            new SwitchExceptionAsyncPattern(),

        }
        .Map(steps => SwitchPatternAsyncContext
                      .With(switchSelector)
                      .Map(context => MatchingPipeline<SwitchPatternAsyncContext, SwitchSelector>
                                     .Given(context)
                                     .Match(steps, [new SwitchAsyncOnError()], [new SwitchAsyncOnException()])))
        .MatchAsync(_ => _.Result,
                    _ => string.Empty);
}