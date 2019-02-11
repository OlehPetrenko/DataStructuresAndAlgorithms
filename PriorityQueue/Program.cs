using System;

namespace PriorityQueue
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("************** START **************");
            Console.WriteLine();

            var priorityQueue = new PriorityQueue<int, string>();

            priorityQueue.Enqueue(0, "Element with priority: 0");
            priorityQueue.Enqueue(5, "Element with priority: 5");
            priorityQueue.Enqueue(3, "Element with priority: 3");
            priorityQueue.Enqueue(4, "Element with priority: 4");
            priorityQueue.Enqueue(5, "Element with priority: 5");
            priorityQueue.Enqueue(9, "Element with priority: 9");

            Console.WriteLine("Added elements with priorities: 0, 5, 3, 4, 5, 9");
            Console.WriteLine();

            while(priorityQueue.HasItems)
                Console.WriteLine(priorityQueue.Dequeue());

            Console.WriteLine();
        }
    }
}
