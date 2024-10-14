﻿using PipelineFp.Steps;
using PipelineFpTest.DataTypes;
using TinyFp;
using TinyFp.Extensions;
using static PipelineFpTest.Switch.Constants.Selectors;

namespace PipelineFpTest.Switch.RawPipeline;

internal class SwitchSouthStep : IStep<Error, SwitchContext>
{
    public Either<Error, SwitchContext> Forward(SwitchContext context)
        => Either<Error, SwitchContext>.Right(context)
        .Map(UpdateContext);

    private static SwitchContext UpdateContext(SwitchContext context)
        => context
        .ToOption(_ => _.InputSelector != SwitchSelector.South)
        .Map(_ => _.With(SouthSelector))
        .OrElse(context);
}