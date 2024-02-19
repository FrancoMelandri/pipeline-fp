namespace PipelineFpTest.Switch;

[Flags]
public enum BuilderStep
{
    None = 1,
    First = 2,
    Second = 4,
    Third = 8
}