namespace PipelineFpTest.Strategy;

internal interface IStrategy
{
    string Act(params string[] actedUpon);
}

