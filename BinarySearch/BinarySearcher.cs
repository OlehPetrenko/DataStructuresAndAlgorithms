using System;

namespace BinarySearch
{
    public sealed class BinarySearcher<T> where T : IComparable<T>
    {
        public T Search(T[] array, T item)
        {
            if (array is null)
                throw new ArgumentNullException(nameof(array));

            var low = array.GetLowerBound(0);
            var high = array.GetUpperBound(0);

            while (low <= high)
            {
                var mid = (low + high) / 2;

                if (array[mid].CompareTo(item) < 0)
                    low = mid + 1;
                else if (array[mid].CompareTo(item) > 0)
                    high = mid - 1;
                else
                    return array[mid];
            }

            throw new InvalidOperationException("Item is not in the array.");
        }

        public T SearchRecursive(T[] array, T item, int low, int high)
        {
            if (array is null)
                throw new ArgumentNullException(nameof(array));

            if (low > high)
                throw new InvalidOperationException("Item is not in the array.");

            var mid = (low + high) / 2;

            if (array[mid].CompareTo(item) < 0)
                return SearchRecursive(array, item, mid + 1, high);

            if (array[mid].CompareTo(item) > 0)
                return SearchRecursive(array, item, low, mid - 1);

            return array[mid];
        }
    }
}
