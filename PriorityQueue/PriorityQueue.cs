using System;
using System.Collections.Generic;
using System.Linq;

namespace PriorityQueue
{
    public sealed class PriorityQueue<TPriority, TItem>
    {
        readonly SortedDictionary<TPriority, Queue<TItem>> _subQueues;

        public int Count => _subQueues.Sum(q => q.Value.Count);

        public bool HasItems => _subQueues.Any();

        public PriorityQueue(IComparer<TPriority> priorityComparer)
        {
            _subQueues = new SortedDictionary<TPriority, Queue<TItem>>(priorityComparer);
        }

        public PriorityQueue() : this(Comparer<TPriority>.Default)
        {
        }

        private void AddQueueOfPriority(TPriority priority)
        {
            _subQueues.Add(priority, new Queue<TItem>());
        }

        private TItem DequeueFromHighPriorityQueue()
        {
            var first = _subQueues.First();
            var nextItem = first.Value.Dequeue();

            if (!first.Value.Any())
                _subQueues.Remove(first.Key);

            return nextItem;
        }

        public TItem Dequeue()
        {
            if (_subQueues.Any())
                return DequeueFromHighPriorityQueue();

            throw new InvalidOperationException("The queue is empty");
        }

        public void Enqueue(TPriority priority, TItem item)
        {
            if (!_subQueues.ContainsKey(priority))
                AddQueueOfPriority(priority);

            _subQueues[priority].Enqueue(item);
        }

        public TItem Peek()
        {
            if (HasItems)
                return _subQueues.First().Value.Peek();

            throw new InvalidOperationException("The queue is empty");
        }
    }
}
