﻿using PipelineFp.Steps;
using PipelineFpTest.DataTypes;
using PipelineFpTest.Switch;
using TinyFp;
using TinyFp.Extensions;
using static PipelineFpTest.Builder.Constants.Steps;

namespace PipelineFpTest.Builder.AsyncPipeline;

internal class BuilderAsyncThirdStep : IAsyncStep<Error, BuilderAsyncStepsContext>
{
    public Task<Either<Error, BuilderAsyncStepsContext>> Forward(BuilderAsyncStepsContext context)
        => Either<Error, BuilderAsyncStepsContext>.Right(context)
        .MapAsync(UpdateContext);

    private static Task<BuilderAsyncStepsContext> UpdateContext(BuilderAsyncStepsContext context)
        => context
        .ToOption(_ => !_.InputStep.HasFlag(BuilderStep.Third))
        .Map(_ => _.With([Third]))
        .OrElse(context)
        .AsTask();
}

