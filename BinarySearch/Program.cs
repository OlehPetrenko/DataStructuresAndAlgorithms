using System;

namespace BinarySearch
{
    public class Program
    {
        static void Main()
        {
            const int valueToFind = 5;

            var array = new int[10];
            
            for (var i = 0; i < array.Length; i++)
                array[i] = i + 2;

            var searcher = new BinarySearcher<int>();
            
            Console.WriteLine("********** REGULAR SEARCH **********");
            Console.WriteLine($"Let's find an element: {valueToFind}");

            try
            {
                var value = searcher.Search(array, valueToFind);
                Console.WriteLine($"Result: {value}");
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.WriteLine();
            Console.WriteLine("********** RECURSIVE SEARCH **********");
            Console.WriteLine($"Let's find an element: {valueToFind}");

            try
            {
                var value = searcher.SearchRecursive(array, valueToFind, array.GetLowerBound(0), array.GetUpperBound(0));
                Console.WriteLine($"Result: {value}");
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.WriteLine();
        }
    }
}
