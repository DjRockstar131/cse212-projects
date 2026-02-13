using System.Collections;
using System.Collections.Generic;

public class BinarySearchTree : IEnumerable<int>
{
    private Node? _root;

    public void Insert(int value)
    {
        if (_root is null)
            _root = new Node(value);
        else
            _root.Insert(value);
    }

    public bool Contains(int value)
    {
        return _root != null && _root.Contains(value);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    // In-order traversal (sorted)
    public IEnumerator<int> GetEnumerator()
    {
        var numbers = new List<int>();
        TraverseForward(_root, numbers);

        foreach (var number in numbers)
            yield return number;
    }

    private void TraverseForward(Node? node, List<int> values)
    {
        if (node is not null)
        {
            TraverseForward(node.Left, values);
            values.Add(node.Data);
            TraverseForward(node.Right, values);
        }
    }

    // Reverse in-order traversal
    public IEnumerable<int> Reverse()
    {
        var numbers = new List<int>();
        TraverseBackward(_root, numbers);

        foreach (var number in numbers)
            yield return number;
    }

    private void TraverseBackward(Node? node, List<int> values)
    {
        if (node is not null)
        {
            TraverseBackward(node.Right, values);
            values.Add(node.Data);
            TraverseBackward(node.Left, values);
        }
    }

    // Height of tree
    public int GetHeight()
    {
        if (_root is null)
            return 0;

        return _root.GetHeight();
    }

    public override string ToString()
    {
        return "<Bst>{" + string.Join(", ", this) + "}";
    }
}
public static class EnumerableExtensions
{
    public static IEnumerable<string> AsString(this IEnumerable<int> source)
    {
        if (source is null)
            return new[] { "<IEnumerable>{}" };

        using var e = source.GetEnumerator();

        // Empty sequence
        if (!e.MoveNext())
            return new[] { "<IEnumerable>{}" };

        var parts = new List<string>();

        // First element
        parts.Add($"<IEnumerable>{{{e.Current}");

        // Middle elements
        while (e.MoveNext())
            parts.Add(e.Current.ToString());

        // Close brace
        int last = parts.Count - 1;
        parts[last] = parts[last] + "}";

        return parts;
    }
}
