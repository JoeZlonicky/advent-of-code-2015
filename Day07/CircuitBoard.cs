using System.Diagnostics;

namespace Day07;

public class CircuitBoard
{
    private const int BitMask = 65535;

    private readonly Dictionary<string, CircuitNode> _nodes;
    private readonly Dictionary<string, int> _cachedValues;

    internal CircuitBoard()
    {
        _nodes = new Dictionary<string, CircuitNode>();
        _cachedValues = new Dictionary<string, int>();
    }

    internal void AddConnection(string leftOperand, string operation, string rightOperand, string name)
    {
        _nodes[name] = new CircuitNode
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
        _cachedValues.Clear();
    }

    internal void OverrideNodeValue(string nodeName, int value)
    {
        CircuitNode node = _nodes[nodeName];
        node.Operation = CircuitNode.InputOperation.None;
        node.PrimaryInput = value.ToString();
        node.SecondaryInput = "";
        _cachedValues.Clear();
    }

    internal int EvaluateNode(string nodeName)
    {
        if (!_nodes.ContainsKey(nodeName)) return 0;
        if (_cachedValues.TryGetValue(nodeName, out var cached)) return cached;
        
        CircuitNode node = _nodes[nodeName];
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
            CircuitNode.InputOperation.And => (left & right) & BitMask,
            CircuitNode.InputOperation.Or => (left | right) & BitMask,
            CircuitNode.InputOperation.Not => ~right & BitMask,
            CircuitNode.InputOperation.LShift => (left << right) & BitMask,
            CircuitNode.InputOperation.RShift => (left >> right) & BitMask,
            CircuitNode.InputOperation.None => left & BitMask,
            _ => left & BitMask
        };
        _cachedValues[nodeName] = result;
        return result;
    }
}