public class SimpleQueue {
    public static void Run() {
        // Test Cases

        Console.WriteLine("Test 1");
        var queue = new SimpleQueue();
        queue.Enqueue(100);
        var value = queue.Dequeue();
        Console.WriteLine(value);

        Console.WriteLine("------------");

        Console.WriteLine("Test 2");
        queue = new SimpleQueue();
        queue.Enqueue(200);
        queue.Enqueue(300);
        queue.Enqueue(400);
        value = queue.Dequeue();
        Console.WriteLine(value);
        value = queue.Dequeue();
        Console.WriteLine(value);
        value = queue.Dequeue();
        Console.WriteLine(value);

        Console.WriteLine("------------");

        Console.WriteLine("Test 3");
        queue = new SimpleQueue();
        try {
            queue.Dequeue();
            Console.WriteLine("Oops ... This shouldn't have worked.");
        }
        catch (IndexOutOfRangeException) {
            Console.WriteLine("I got the exception as expected.");
        }
    }

    private readonly List<int> _queue = new();

    // Must be public so tests can call it
    public void Enqueue(int value) {
        // add to the back
        _queue.Add(value);
    }

    // Must be public so tests can call it
    public int Dequeue() {
        if (_queue.Count <= 0)
            throw new IndexOutOfRangeException();

        // remove from the front
        var value = _queue[0];
        _queue.RemoveAt(0);
        return value;
    }
}
