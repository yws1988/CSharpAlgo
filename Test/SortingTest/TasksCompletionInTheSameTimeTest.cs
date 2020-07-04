namespace SortingTest
{
    using CSharpAlgo.Sorting;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class TasksCompletionInTheSameTimeTest
    {
        [Test]
        public void GetThreadAssignments_Return_Thread_Assignments()
        {
            var tasks = new List<(int, int)>()
            {
                (1, 3),
                (1, 4),
                (1, 5),
                (1, 6),
                (1, 7),
                (2, 9),
                (3, 11)
            };

            int n = 6;

            var result = TasksCompletionInTheSameTime.GetThreadAssignments(tasks, n);

            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6, 1 }, result);
        }

        [Test]
        public void GetThreadAssignments_Return_Null_When_Assignments_Is_Impossible()
        {
            var tasks = new List<(int, int)>()
            {
                (1, 3),
                (1, 4),
                (1, 5),
                (1, 6),
                (1, 7),
                (2, 9),
                (1, 11)
            };

            int n = 6;

            var result = TasksCompletionInTheSameTime.GetThreadAssignments(tasks, n);

            Assert.IsNull(result);
        }
    }
}
