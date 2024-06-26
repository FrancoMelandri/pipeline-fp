﻿using PipelineFp.Steps;
using TinyFp;
using TinyFp.Extensions;
using static PipelineFp.Extensions.EitherExtensions;
using static TinyFp.Prelude;

namespace PipelineFp.Pipelines;

public class Pipeline<TContext> : IPipeline<TContext>
{
    private readonly TContext _context;

    private Pipeline(TContext context)
    {
        _context = context;
    }

    public static IPipeline<TContext> Given(TContext context)
        => new Pipeline<TContext>(context);

    public Either<TError, TContext> Fit<TError>(IEnumerable<IStep<TError, TContext>> steps)
        => Fit(steps, _context, [], []);

    public Task<Either<TError, TContext>> Fit<TError>(IEnumerable<IAsyncStep<TError, TContext>> steps)
        => Fit(steps, _context, [], []);

    public Task<Either<TError, TContext>> Fit<TError>(
        IEnumerable<IAsyncStep<TError, TContext>> steps,
        IEnumerable<IOnErrorAsyncStep<TError, TContext>> onFailSteps,
        IEnumerable<IOnExceptionAsyncStep<TError, TContext>> onExceptionSteps)
        => Fit(steps, _context, onFailSteps, onExceptionSteps);

    public Either<TError, TContext> Fit<TError>(
        IEnumerable<IStep<TError, TContext>> steps,
        IEnumerable<IOnErrorStep<TError, TContext>> onFailSteps,
        IEnumerable<IOnExceptionStep<TError, TContext>> onExceptionSteps)
        => Fit(steps, _context, onFailSteps, onExceptionSteps);

    private static Task<Either<TError, TContext>> Fit<TError>(
        IEnumerable<IAsyncStep<TError, TContext>> steps,
        TContext context,
        IEnumerable<IOnErrorAsyncStep<TError, TContext>> onFailSteps,
        IEnumerable<IOnExceptionAsyncStep<TError, TContext>> onExceptionSteps)
        => TryAsync(() => steps
                         .FoldAsync(Right<TError, TContext>(context),
                                   (state, step) => state.BindAsync(_ => step.Forward(context)))
                         .BindLeftAsync(error => onFailSteps
                                                 .ToOption(_ => !_.Any())
                                                 .Map(_ => _.FoldAsync(Right<TError, TContext>(context),
                                                                      (state, step) => state.BindAsync(_ => step.Forward(_, error))))
                                                 .OrElse(Left<TError, TContext>(error).AsTask())))
        .OnFail(ex => onExceptionSteps
                     .FoldAsync(Right<TError, TContext>(context),
                               (state, step) => state.BindAsync(_ => step.Forward(_, ex))));

    private static Either<TError, TContext> Fit<TError>(
       IEnumerable<IStep<TError, TContext>> steps,
       TContext context,
       IEnumerable<IOnErrorStep<TError, TContext>> onFailSteps,
       IEnumerable<IOnExceptionStep<TError, TContext>> onExceptionSteps)
       => Try(() => steps
                   .Fold(Right<TError, TContext>(context),
                        (state, step) => state.Bind(_ => step.Forward(_)))
                   .BindLeft(error => onFailSteps
                                      .ToOption(_ => !_.Any())
                                      .Map(_ => _.Fold(Right<TError, TContext>(context),
                                                      (state, step) => state.Bind(_ => step.Forward(_, error))))
                                      .OrElse(error)))
       .OnFail(ex => onExceptionSteps
                    .Fold(Right<TError, TContext>(context),
                         (state, step) => state.Bind(_ => step.Forward(_, ex))));
}