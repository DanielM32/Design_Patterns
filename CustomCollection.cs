using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1OOD
{
    // Define the interface for custom collections
    public interface ICustomCollection<T>
    {
        void Add(T item);
        void Remove(T item);
        IEnumerator<T> GetForwardIterator();
        IEnumerator<T> GetReverseIterator();
        //Task4

    }

    // Implement the doubly linked list collection
    public class CustomLinkedList<T> : ICustomCollection<T>
    {
        private LinkedList<T> _list = new LinkedList<T>();

        public void Add(T item) => _list.AddLast(item);

        public void Remove(T item) => _list.Remove(item);

        public IEnumerator<T> GetForwardIterator() => _list.GetEnumerator();

        public IEnumerator<T> GetReverseIterator()
        {
            LinkedListNode<T> thisNode = _list.Last;
            while (thisNode != null)
            {
                yield return thisNode.Value;
                thisNode = thisNode.Previous;
            }
        }



    }

    // Implement the vector collection
    public class CustomVector<T> : ICustomCollection<T>
    {
        private List<T> _list = new List<T>();

        public void Add(T item) => _list.Add(item);

        public void Remove(T item) => _list.Remove(item);

        public IEnumerator<T> GetForwardIterator() => _list.GetEnumerator();

        public IEnumerator<T> GetReverseIterator()
        {
            for (int i = _list.Count - 1; i >= 0; i--)
                yield return _list[i];
        }
    }

    // Implement the find algorithm (first part from homework)
    public static class CollectionAlgorithms
    {
        public static T Find<T>(ICustomCollection<T> collection, Func<T, bool> predicate, bool searchFromBeginning)
        {
            IEnumerator<T> iterator = searchFromBeginning ? collection.GetForwardIterator() : collection.GetReverseIterator();
            while (iterator.MoveNext())
            {
                T item = iterator.Current;
                if (predicate(item))
                    return item;
            }
            return default(T);
        }
        //Lab find algorithm
        public static T Find<T>(IEnumerator<T> iterator, Func<T, bool> predicate)
        {
            while (iterator.MoveNext())
            {
                T current = iterator.Current;
                if (predicate(current))
                {
                    return current;
                }
            }

            return default(T);
        }

        //Foreach algorithm
        public static void ForEach<T>(IEnumerator<T> iterator, Action<T> function)
        {
            while (iterator.MoveNext())
            {
                T current = iterator.Current;
                function(current);
            }
        }

        //Count If algorithm

        public static int CountIf<T>(IEnumerator<T> iterator, Func<T, bool> predicate)
        {
            int counter = 0;
            while (iterator.MoveNext())
            {
                T current = iterator.Current;
                if (predicate(current))
                {
                    counter++;
                }
            }

            return counter;
        }

        // Implement the print algorithm
        public static void Print<T>(ICustomCollection<T> collection, Func<T, bool> predicate, bool searchFromBeginning)
        {
            IEnumerator<T> iterator = searchFromBeginning ? collection.GetForwardIterator() : collection.GetReverseIterator();
            while (iterator.MoveNext())
            {
                T item = iterator.Current;
                if (predicate(item))
                    Console.WriteLine(item);
            }
        }

        public class SortedArray<T> : ICustomCollection<T>
        {
            private List<T> _list = new List<T>();
            private readonly Comparison<T> _comparator;

            public SortedArray(Comparison<T> comparator)
            {
                _comparator = comparator;
            }

            public void Add(T item)
            {
                // Find the index of the first element greater than the item to insert
                int index = _list.Count;
                for (int i = 0; i < _list.Count; i++)
                {
                    if (_comparator(_list[i], item) > 0)
                    {
                        index = i;
                        break;
                    }
                }

                // Insert the item at the found index
                if (index == _list.Count)
                {
                    _list.Add(item);
                }
                else
                {
                    // Shift elements to the right of the index to make room for the new item
                    _list.Add(default(T));
                    for (int i = _list.Count - 1; i > index; i--)
                    {
                        _list[i] = _list[i - 1];
                    }
                    _list[index] = item;
                }
            }
            public void Remove(T item)
            {
                int itemindex = FindIndex(item);
                if (itemindex != -1)
                {
                    RemoveAt(itemindex);
                }
            }

            private int FindIndex(T item)
            {
                int leftindex = 0;
                int rightindex = _list.Count - 1;

                while (leftindex <= rightindex)
                {
                    int middleindex = leftindex + (rightindex - leftindex) / 2;
                    int compareResult = _comparator(_list[middleindex], item);

                    if (compareResult == 0)
                    {
                        return middleindex;
                    }
                    else if (compareResult < 0)
                    {
                        leftindex = middleindex + 1;
                    }
                    else
                    {
                        rightindex = middleindex - 1;
                    }
                }

                return -1;
            }

            private void RemoveAt(int index)
            {
                if (index == 0) 
                {
                    _list.RemoveAt(0);
                }
                else if (index == _list.Count - 1) 
                {
                    _list.RemoveAt(_list.Count - 1);
                }
                else // Removing from the middle by shifting the element to the beginning
                {
                    while (index > 0)
                    {
                        _list[index] = _list[index - 1];
                        index--;
                    }
                    _list.RemoveAt(0);
                }
            }


            public IEnumerator<T> GetForwardIterator() => _list.GetEnumerator();

            public IEnumerator<T> GetReverseIterator()
            {
                for (int i = _list.Count - 1; i >= 0; i--)
                {
                    yield return _list[i];
                }
            }
        }

    }






}
