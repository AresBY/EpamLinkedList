using System;
using System.Collections;
using System.Collections.Generic;

namespace Mentoring.LinkedList
{
    public class LessonList<T> : ILessonList<T>
    {
        private class Node<TN>
        {
            public TN Data { get; set; }
            public Node<TN> Next { get; set; }
            public Node(TN data)
            {
                Data = data;
            }
        }

        private Node<T> First { get; set; } = null;
        private Node<T> Current { get; set; } = null;

        public void Add(T item)
        {
            Node<T> node = new Node<T>(item);
            if (First != null)
            {
                SetCurrentToLast();// Здесь можно обойтись и без перебора, если замарочиться.
                Current.Next = node;
            }
            else
            {
                First = node;
            }
            Current = node;
        }
        public void AddRange(params T[] item)
        {
            if (item.Length == 0)
                return;

            if (First != null)
            {
                SetCurrentToLast();
                Current.Next = new Node<T>(item[0]);
                Current = Current.Next;
            }
            else
            {
                Current = new Node<T>(item[0]);
                First = Current;
            }

            for (int i = 1; i < item.Length; i++)
            {
                Current.Next = new Node<T>(item[i]);
                Current = Current.Next;
            }
        }
        public void Insert(int index, T item)
        {
            if (index < 0)
                throw new IndexOutOfRangeException();

            Node<T> node = new Node<T>(item);
            if (index == 0)
            {
                node.Next = First;
                First = node;
                return;
            }

            int curIndex = 0;
            Current = First;
            while (Current != null && curIndex < index && Current.Next != null)
            {
                curIndex++;
                if (curIndex == index)
                {
                    Node<T> temp = Current.Next;
                    Current.Next = node;
                    node.Next = temp;
                    return;
                }
                Current = Current.Next;
            }
            throw new IndexOutOfRangeException();
        }

        public void Clear()
        {
            First = null;
            Current = null;
        }

        public bool Contains(T item)
        {
            if (First == null)
                return false;

            Current = First;

            do
            {
                if (Current.Data.Equals(item))
                {
                    return true;
                }
                Current = Current.Next;
            }
            while (Current != null);

            return false;
        }


        public void CopyTo(T[] array)
        {
            CopyTo(array, 0);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            int inputIndex = arrayIndex;
            if (First == null)
            {
                throw new Exception("Cannot copy, because list is empty");
            }

            Current = First;
            int curIndex = -1;
            while (Current != null)
            {
                curIndex++;

                if (curIndex < inputIndex)
                {
                    Current = Current.Next;
                    continue;
                }

                if (curIndex - arrayIndex > array.Length - 1)
                {
                    throw new ArgumentException("The resulting array is not long enough.");
                }
                array[curIndex - arrayIndex] = Current.Data;
                Current = Current.Next;
            }
        }
        public bool Remove(T item)
        {
            if (First == null)
            {
                throw new Exception("Cannot remove element from empty List");
            }

            if (First.Data.Equals(item))
            {
                First = First.Next;
                return true;
            }

            Current = First;
            while (Current.Next != null)
            {
                if (Current.Next.Data.Equals(item))
                {
                    Current.Next = Current.Next.Next;
                    return true;
                }
                Current = Current.Next;
            }

            return false;
        }
        public bool RemoveAt(int index)
        {
            if (index < 0)
                throw new ArgumentException("Index cannot be < 0");

            if (First == null)
                throw new Exception("Cannot remove element from empty List");

            Current = First;
            int curIndex = -1;
            Node<T> prev = null;
            while (Current != null)
            {
                curIndex++;
                if (curIndex == index)
                {
                    if (curIndex == 0)
                    {
                        First = First.Next;
                        return true;
                    }

                    prev.Next = Current.Next;
                    return true;
                }

                prev = Current;
                Current = Current.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (First != null)
            {
                Current = First;
                while (true)
                {
                    yield return Current.Data;

                    if (Current.Next != null)
                    {
                        Current = Current.Next;
                    }
                    else
                    {
                        yield break;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private void SetCurrentToLast()
        {
            if (First == null)
                throw new Exception("Cannot set Curent to Last, because list is empty");

            Current = First;
            while (Current.Next != null)
            {
                Current = Current.Next;
            }

        }
    }
}
