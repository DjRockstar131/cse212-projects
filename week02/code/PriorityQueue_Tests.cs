using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
// Scenario: Enqueue three items with different priorities.
// Expected Result: Dequeue returns highest priority first, then next, then last.
// Defect(s) Found: Dequeue did not remove the item from the queue and/or the search skipped the last element.
public void TestPriorityQueue_1()
{
    var priorityQueue = new PriorityQueue();
    priorityQueue.Enqueue("low", 1);
    priorityQueue.Enqueue("high", 5);
    priorityQueue.Enqueue("mid", 3);

    Assert.AreEqual("high", priorityQueue.Dequeue());
    Assert.AreEqual("mid", priorityQueue.Dequeue());
    Assert.AreEqual("low", priorityQueue.Dequeue());
}

[TestMethod]
// Scenario: Enqueue multiple items with the same priority.
// Expected Result: Items with the same priority are dequeued in FIFO order (A then B then C).
// Defect(s) Found: When priorities were equal, Dequeue returned the most recently added item instead of the earliest.
public void TestPriorityQueue_2()
{
    var priorityQueue = new PriorityQueue();
    priorityQueue.Enqueue("A", 2);
    priorityQueue.Enqueue("B", 2);
    priorityQueue.Enqueue("C", 2);

    Assert.AreEqual("A", priorityQueue.Dequeue());
    Assert.AreEqual("B", priorityQueue.Dequeue());
    Assert.AreEqual("C", priorityQueue.Dequeue());
}

}