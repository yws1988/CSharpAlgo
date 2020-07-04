/*
 There are m tasks, each task takes time interval [a, b], a computer processor can have n
 threads numero from 1 to n, each thread can only process one task in the same time. 
 Give all the time intervals for m tasks. Output the thread assignments for each task in order
 the computer can finish all the tasks.
    For example 6 threads with 7 following tasks:
    1 3
    1 4
    1 5
    1 6
    1 7
    2 9
    3 11

    Return
    1 2 3 4 5 6 1
    Assign your 6 threads to the first 6 queries. For the 7th query starting
    at time 3, you can use cable 1 which was assigned to a request ending at the time
 */

namespace CSharpAlgo.Sorting
{
    using System.Collections.Generic;
    using System.Linq;

    public class TasksCompletionInTheSameTime
    {
        public static int[] GetThreadAssignments(List<(int, int)> tasks, int numOfThreads)
        {
            var tasksWithIndex = new List<(int, int, int)>();

            int numOfTasks = tasks.Count();
            for (int i = 0; i < numOfTasks; i++)
            {
                tasksWithIndex.Add((tasks[i].Item1, tasks[i].Item2, i));
            }

            tasksWithIndex.Sort();

            var currentEndTimesOfThreads = new int[numOfThreads];
            var assignments = new int[numOfTasks];

            foreach (var item in tasksWithIndex)
            {
                bool hasAvailableThread = false;

                for (int k = 0; k < numOfThreads; k++)
                {
                    if (currentEndTimesOfThreads[k] <= item.Item1)
                    {
                        hasAvailableThread = true;
                        currentEndTimesOfThreads[k] = item.Item2;
                        assignments[item.Item3] = k + 1;

                        break;
                    }
                }

                if (!hasAvailableThread)
                {
                    return null;
                }
            }

            return assignments;
        }
    }
}
