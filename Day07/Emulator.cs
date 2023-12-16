namespace Day07;

public class Emulator
{
    private static int _maxValue = 65535;
    
    private Dictionary<string, int> variables;

    internal Emulator()
    {
        variables = new Dictionary<string, int>();
    }

    internal void ExecuteCommand(string leftOperand, string operation, string rightOperand, string outputVariable)
    {
        int left = ParseValue(leftOperand);
        int right = ParseValue(rightOperand);
        ExecuteCommand(left, operation, right, outputVariable);
    }

    private void ExecuteCommand(int leftOperand, string operation, int rightOperand, string outputVariable)
    {
        int result = operation switch
        {
            "AND" => AndOperation(leftOperand, rightOperand),
            "OR" => OrOperation(leftOperand, rightOperand),
            "NOT" => NotOperation(rightOperand),
            "LSHIFT" => LShiftOperation(leftOperand, rightOperand),
            "RSHIFT" => RShiftOperation(leftOperand, rightOperand),
            _ => leftOperand
        };

        Store(outputVariable, result);
    }

    internal int GetVariableValue(string variableName)
    {
        return variables.GetValueOrDefault(variableName, 0);
    }

    private void Store(string variable, int value)
    {
        variables[variable] = value % (_maxValue + 1);
    }

    private static int AndOperation(int lhs, int rhs)
    {
        return lhs & rhs;
    }

    private static int OrOperation(int lhs, int rhs)
    {
        return lhs | rhs;
    }

    private static int NotOperation(int value)
    {
        return _maxValue - value;
    }

    private static int RShiftOperation(int lhs, int rhs)
    {
        return lhs >> rhs;
    }

    private static int LShiftOperation(int lhs, int rhs)
    {
        return lhs << rhs;
    }

    private int ParseValue(string value)
    {
        return int.TryParse(value, out int i) ? i : variables.GetValueOrDefault(value, 0);
    }
}