using System.Collections.Generic;

namespace Mentoring.LinkedList
{
    public interface ILessonList<T> : IEnumerable<T>
    {
        void Add(T item);
        void AddRange(params T[] item);
        void Insert(int index, T item);
        void Clear();
        bool Contains(T item);
        void CopyTo(T[] array);
        void CopyTo(T[] array, int arrayIndex);
        bool Remove(T item);
        bool RemoveAt(int index);
    }
}