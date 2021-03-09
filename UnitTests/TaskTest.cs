using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.LinkedList.UnitTests
{
    [TestClass()]
    public class TaskTest
    {
        #region Add
        public void AddTest(ILessonList<string> data, ILessonList<string> expected, string item, string assertMessage)
        {
            data.Add(item);
            Assert.IsTrue(data.SequenceEqual(expected), assertMessage);
        }
        public void AddTest(ILessonList<int> data, ILessonList<int> expected, int item, string assertMessage)
        {
            data.Add(item);
            Assert.IsTrue(data.SequenceEqual(expected), assertMessage);
        }

        [TestMethod()]
        [TestCategory("Add")]
        public void Add_Should_Return_Changed_List()
        {
            AddTest(
                new LessonList<string> { "a", "aa", "aaa", "aaaa", "aaaaa" },
                new LessonList<string> { "a", "aa", "aaa", "aaaa", "aaaaa", "" },
                string.Empty,
                "Method 'Add' should return changed list");
            AddTest(
              new LessonList<int> { 2 },
              new LessonList<int> { 2, 1 },
              1,
              "Method 'Add' should return changed list");
        }
        #endregion Add

        #region AddRange
        public void AddRangeTest(ILessonList<string> data, string[] array, ILessonList<string> expected, string assertMessage)
        {
            data.AddRange(array);
            Assert.IsTrue(data.SequenceEqual(expected), assertMessage);
        }
        public void AddRangeTest(ILessonList<int> data, int[] array, ILessonList<int> expected, string assertMessage)
        {
            data.AddRange(array);
            Assert.IsTrue(data.SequenceEqual(expected), assertMessage);
        }

        [TestMethod()]
        [TestCategory("AddRange")]
        public void AddRange_Should_Return_Changed_List()
        {
            AddRangeTest(
                new LessonList<string> { "a", "aa" },
                new string[] { "aaa", "aaaa", "aaaaa" },
                new LessonList<string> { "a", "aa", "aaa", "aaaa", "aaaaa" },
                "Method 'AddRange' should return changed list");
            AddRangeTest(
              new LessonList<int> { 2 },
              new int[] { 3, 4, 5 },
              new LessonList<int> { 2, 3, 4, 5 },
              "Method 'Add' should return changed list");
        }
        #endregion AddRange

        #region Insert
        public void InsertTest(ILessonList<string> data, ILessonList<string> expected, int index, string item, string assertMessage)
        {
            data.Insert(index, item);
            Assert.IsTrue(data.SequenceEqual(expected), assertMessage);
        }
        public void InsertTest(ILessonList<int> data, ILessonList<int> expected, int index, int item, string assertMessage)
        {
            data.Insert(index, item);
            Assert.IsTrue(data.SequenceEqual(expected), assertMessage);
        }


        public void InsertTest(ILessonList<int> data, int index)
        {
            data.Insert(index, 0);
        }
        [TestMethod()]
        [TestCategory("Insert")]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Insert_Should_Return_Changed_List()
        {
            InsertTest(
                new LessonList<string> { "a", "aa" },
                new LessonList<string> { "a", "aaa", "aa" },
                1,
                "aaa",
                "Method 'Insert' should return changed list");
            InsertTest(
                new LessonList<int> { 1, 2 },
                new LessonList<int> { 1, 3, 2 },
                1,
                3,
                "Method 'Insert' should return changed list");
            InsertTest(
                new LessonList<int> { },
                new LessonList<int> { 3 },
                0,
                3,
                "Method 'Insert' should return changed list");
            //InsertTest(
            //   new LessonList<int> { },
            //   5);
        }
        #endregion Insert

        #region Clear
        public void ClearTest(ILessonList<string> data, ILessonList<string> expected, string assertMessage)
        {
            data.Clear();
            Assert.IsTrue(data.SequenceEqual(expected), assertMessage);
        }

        [TestMethod()]
        [TestCategory("Clear")]
        public void Clear_Should_Return_Clear_List()
        {
            ClearTest(
                new LessonList<string> { "a", "aa" },
                new LessonList<string> { },
                "Method 'Clear' should return clear list");
        }
        #endregion Clear

        #region Contains
        public void ContainsTest(ILessonList<int> data, int item, bool expected, string assertMessage)
        {
            Assert.IsTrue(data.Contains(item) == expected, assertMessage);
        }

        [TestMethod()]
        [TestCategory("Contains")]
        public void Contains_Should_Return_True_or_False()
        {
            ContainsTest(
                new LessonList<int> { 1, 2 }, 1, true, "Method 'Contains' should return true");
            ContainsTest(
               new LessonList<int> { 1, 2 }, 2, true, "Method 'Contains' should return true");
            ContainsTest(
               new LessonList<int> { 1, 2 }, 3, false, "Method 'Contains' should return false");
        }
        #endregion Contains

        #region CopyTo
        public void CopyTo(ILessonList<string> data, string[] expected, string assertMessage)
        {
            CopyTo(data, 0, expected, assertMessage);
        }
        public void CopyTo(ILessonList<string> data, int index, string[] expected, string assertMessage)
        {
            int count = data.Count() - index;

            if (count < 0)
                throw new ArgumentException($"Index is wrong { index }");


            string[] arrayForCopy = new string[count];
            data.CopyTo(arrayForCopy, index);
            Assert.IsTrue(arrayForCopy.SequenceEqual(expected), assertMessage);
        }

        [TestMethod()]
        [TestCategory("CopyTo")]
        public void CopyTo_Should_Return_Changed_List()
        {
            CopyTo(
                new LessonList<string> { "a", "aa", "aaa" },
                new string[] { "a", "aa", "aaa" },
                "Method 'CopyTo' should create changed list");
            CopyTo(
              new LessonList<string> { "a", "aa", "aaa" },
               2,
              new string[] { "aaa" },
              "Method 'CopyTo' should create changed list");
        }
        #endregion CopyTo

        #region Remove

        public void Remove(ILessonList<string> data, string item, ILessonList<string> expected, string assertMessage)
        {
            data.Remove(item);
            Assert.IsTrue(data.SequenceEqual(expected), assertMessage);
        }

        [TestMethod()]
        [TestCategory("Remove")]
        public void Remove_Should_Return_Changed_List()
        {
            Remove(
                new LessonList<string> { "a", "aa", "aaa" },
                "aa",
                 new LessonList<string> { "a", "aaa" },
                "Method 'Remove' should return changed list");
            Remove(
               new LessonList<string> { "a", "aa", "aaa" },
               "aaaa",
                new LessonList<string> { "a", "aa", "aaa" },
               "Method 'Remove' should return same list");

        }
        #endregion Remove

        #region RemoveAt

        public void RemoveAt(ILessonList<string> data, int index, ILessonList<string> expected, string assertMessage)
        {
            data.RemoveAt(index);
            Assert.IsTrue(data.SequenceEqual(expected), assertMessage);
        }

        [TestMethod()]
        [TestCategory("RemoveAt")]
        public void RemoveAt_Should_Return_Changed_List()
        {
            RemoveAt(
                new LessonList<string> { "a", "aa", "aaa" },
                2,
                 new LessonList<string> { "a", "aa" },
                "Method 'RemoveAt' should return changed list");
            RemoveAt(
               new LessonList<string> { "a", "aa", "aaa" },
               22,
                new LessonList<string> { "a", "aa", "aaa" },
               "Method 'RemoveAt' should return same list");

        }
        #endregion RemoveAt
    }
}
