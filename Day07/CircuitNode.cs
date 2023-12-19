namespace Day07;

internal class CircuitNode
{
    internal enum InputOperation
    {
        None,
        And,
        Or,
        Not,
        LShift,
        RShift
    }
    
    // Inputs can either be a number (as a string) or the id of another node
    internal string PrimaryInput { set; get; } = "";
    internal string SecondaryInput { set; get; } = "";
    internal InputOperation Operation { set; get; } = InputOperation.None;
}