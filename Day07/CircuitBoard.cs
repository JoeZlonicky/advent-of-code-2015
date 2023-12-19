using System.Diagnostics;

namespace Day07;

public class CircuitBoard
{
    private static readonly int bitMask = 65535;
    
    private Dictionary<string, CircuitNode> nodes;
    private Dictionary<string, int> cachedValues;

    internal CircuitBoard()
    {
        nodes = new Dictionary<string, CircuitNode>();
        cachedValues = new Dictionary<string, int>();
    }

    internal void AddConnection(string leftOperand, string operation, string rightOperand, string name)
    {
        nodes[name] = new CircuitNode
        {
            PrimaryInput = leftOperand,
            SecondaryInput = rightOperand,
            Operation = operation switch
            {
                "AND" => CircuitNode.InputOperation.And,
                "OR" => CircuitNode.InputOperation.Or,
                "NOT" => CircuitNode.InputOperation.Not,
                "LSHIFT" => CircuitNode.InputOperation.LShift,
                "RSHIFT" => CircuitNode.InputOperation.RShift,
                _ => CircuitNode.InputOperation.None
            }
        };
    }

    internal int EvaluateNode(string nodeName)
    {
        if (!nodes.ContainsKey(nodeName)) return 0;
        if (cachedValues.TryGetValue(nodeName, out var cached)) return cached;
        
        CircuitNode node = nodes[nodeName];
        if (!int.TryParse(node.PrimaryInput, out var left))
        {
            left = EvaluateNode(node.PrimaryInput);
        }

        if (!int.TryParse(node.SecondaryInput, out var right))
        {
            right = EvaluateNode(node.SecondaryInput);
        }
        
        int result = node.Operation switch
        {
            CircuitNode.InputOperation.And => (left & right) & bitMask,
            CircuitNode.InputOperation.Or => (left | right) & bitMask,
            CircuitNode.InputOperation.Not => ~right & bitMask,
            CircuitNode.InputOperation.LShift => (left << right) & bitMask,
            CircuitNode.InputOperation.RShift => (left >> right) & bitMask,
            CircuitNode.InputOperation.None => left & bitMask,
            _ => left & bitMask
        };
        cachedValues[nodeName] = result;
        return result;
    }
}