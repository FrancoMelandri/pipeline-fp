﻿using PipelineFp.Steps;
using PipelineFpTest.DataTypes;
using PipelineFpTest.Switch;
using TinyFp;
using TinyFp.Extensions;
using static PipelineFpTest.Builder.Constants.Steps;

namespace PipelineFpTest.Builder.Pipeline;

internal class BuilderSecondStep : IStep<Error, BuilderStepsContext>
{
    public Either<Error, BuilderStepsContext> Forward(BuilderStepsContext context)
        => Either<Error, BuilderStepsContext>.Right(context)
        .Map(UpdateContext);

    private static BuilderStepsContext UpdateContext(BuilderStepsContext context)
        => context
        .ToOption(_ => !_.InputStep.HasFlag(BuilderStep.Second))
        .Map(_ => _.With([Second]))
        .OrElse(context);
}
