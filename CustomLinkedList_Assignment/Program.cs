using System.Collections;

var list = new SinglyLinkedList<string>();

list.AddToFront("a");
list.AddToFront("b");
list.AddToFront("c");

//list.Add("e");
//list.Add("f");
//list.Clear();

//list.Remove("c");

//Console.WriteLine("Contains c ? " + list.Contains("c"));
//Console.WriteLine("Contains d ? " + list.Contains("d"));

var arr = new string[7];

list.CopyTo(arr, 2);

foreach (var item in list)
{
    Console.WriteLine(item);
}

Console.ReadKey();

public interface ILinkedList<T> : ICollection<T>
{
    void AddToFront(T item);
    void AddToEnd(T item);
}

public class SinglyLinkedList<T> : ILinkedList<T?>
{
    private Node<T>? _head;
    private int _count;

    public int Count => _count;

    public bool IsReadOnly => false;

    public void Add(T? item)
    {
        AddToEnd(item);
    }

    public void AddToEnd(T? item)
    {
        var newNode = new Node<T>(item);
        if (_head is null)
        {
            _head = newNode;
        } else
        {
            var tail = GetNodes().Last();
            tail.Next = newNode;
        }
        ++_count;
    }

    public void AddToFront(T? item)
    {
        var newHead = new Node<T>(item)
        {
            Next = _head
        };
        _head = newHead;
        _count++;
    }

    public void Clear()
    {
        Node<T>? current = _head;
        while (current is not null)
        {
            Node<T>? temporary = current;
            current = current.Next;
            temporary.Next = null;
        }
        _head = null;
        _count = 0;
    }

    public bool Contains(T? item)
    {
        if (item is null)
        {
            return GetNodes().Any( node => node.Value is null );
        }
        return GetNodes().Any( node => item.Equals(node.Value) );
    }

    public void CopyTo(T?[] array, int arrayIndex)
    {

        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }
        if (arrayIndex < 0 || arrayIndex >= array.Length )
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex));
        }
        if (array.Length < _count + arrayIndex)
        {
            throw new ArithmeticException("Array is not long enough");
        }
        foreach (var node in GetNodes())
        {
            array[arrayIndex] = node.Value;
            ++arrayIndex;
        }
    }

    public bool Remove(T? item)
    {
        Node<T>? predecessor = null;
        foreach (var node in GetNodes() )
        {
            if ((node.Value is null && item is null) || (node.Value is not null && node.Value.Equals(item)))
            {
                if (predecessor is null)
                {
                    _head = node.Next;
                } else
                {
                    predecessor.Next = node.Next;
                }

                --_count;
                return true;
            }
            predecessor = node; 
        }
        return false;
    }

    public IEnumerator<T?> GetEnumerator()
    {
        foreach (var node in GetNodes())
        {
            yield return node.Value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private IEnumerable<Node<T>> GetNodes()
    {
        if (_head is null)
        {
            yield break;
        }
        Node<T>? current = _head;

        while (current is not null)
        {
            yield return current;
            current = current.Next;
        }
        {
            
        }

    }


}

public class Node<T>
{
    public T? Value { get; set; }

    public Node<T>? Next { get; set; }

    public Node(T? value)
    {
        Value = value;
    }

    public override string ToString() => $"Value: {Value}, Next: {(Next is null ? "NULL" : Next.Value )} ";

}