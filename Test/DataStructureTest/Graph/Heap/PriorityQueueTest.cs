namespace DataStructureTest.Graph.Heap
{
    using DataStructure.Heap;
    using DataStructure.Model;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PriorityQueueTest
    {
        public PriorityQueueTest Test { get; set; }

        [SetUp]
        public void Init()
        {
            Test = new PriorityQueueTest();
        }

        [Test]
        public void Dequeue_Returns_Expected_Employee()
        {
            // Arrange 
            PriorityQueue<Employee> priorityQueue = new PriorityQueue<Employee>();
            priorityQueue.Enqueue(new Employee("Litao", 100));
            priorityQueue.Enqueue(new Employee("JingLi", 12));
            priorityQueue.Enqueue(new Employee("Leonard", 8));
            priorityQueue.Enqueue(new Employee("Shen", 3));
            priorityQueue.Enqueue(new Employee("Vincent", 13));
            priorityQueue.Enqueue(new Employee("Xinlong", 11));

            // Act
            var result = priorityQueue.Dequeue();

            // Assert
            Assert.AreEqual("Shen", result.Name);
        }

        [Test]
        public void Dequeue_Returns_Expected_Value()
        {
            // Arrange 
            PriorityQueue<double> queue = new PriorityQueue<double>((a, b) => { return Math.Sign((a - Math.Floor(a)) - (b - Math.Floor(b))); });
            queue.Enqueue(100.25);
            queue.Enqueue(110.37);
            queue.Enqueue(10.2);
            queue.Enqueue(4.45);
            queue.Enqueue(400.15);

            // Act
            var result = queue.Dequeue();

            // Assert
            Assert.AreEqual(400.15, result);
        }
    }
}
