using System;
using System.Collections.Generic;
using System.Linq;

namespace PriorityQueue
{
    public sealed class PriorityQueue<TPriority, TItem>
    {
        readonly SortedDictionary<TPriority, Queue<TItem>> _subqueues;

        public int Count => _subqueues.Sum(q => q.Value.Count);
        
        public bool HasItems => _subqueues.Any();
        
        public PriorityQueue(IComparer<TPriority> priorityComparer)
        {
            _subqueues = new SortedDictionary<TPriority, Queue<TItem>>(priorityComparer);
        }

        public PriorityQueue() : this(Comparer<TPriority>.Default)
        {
        }

        private void AddQueueOfPriority(TPriority priority)
        {
            _subqueues.Add(priority, new Queue<TItem>());
        }

        private TItem DequeueFromHighPriorityQueue()
        {
            var first = _subqueues.First();
            var nextItem = first.Value.Dequeue();

            if (!first.Value.Any())
                _subqueues.Remove(first.Key);

            return nextItem;
        }

        public TItem Dequeue()
        {
            if (_subqueues.Any())
                return DequeueFromHighPriorityQueue();

            throw new InvalidOperationException("The queue is empty");
        }

        public void Enqueue(TPriority priority, TItem item)
        {
            if (!_subqueues.ContainsKey(priority))
                AddQueueOfPriority(priority);

            _subqueues[priority].Enqueue(item);
        }

        public TItem Peek()
        {
            if (HasItems)
                return _subqueues.First().Value.Peek();

            throw new InvalidOperationException("The queue is empty");
        }
    }
}
