using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Mentoring.LinkedList.PerformanceDemo
{
    class Person
    {
        public int Age = 0;
        public string Name = "Vasia";
    }
    class Program
    {
        static void Main(string[] args)
        {
            int count = 5000;

            Person[] arr = new Person[count];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new Person();
            }

            while (true)
            {
                Console.WriteLine("___________________________________");

                MicrosoftList(count, arr);

                LessonList(count, arr);

                Console.ReadKey();
            }
        }

        private static void MicrosoftList(int count, Person[] arr)
        {
            List<Person> micList = new List<Person>();

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            micList.AddRange(arr);
            stopWatch.Stop();

            Console.WriteLine($"Время MicrosoftList AddRange { stopWatch.Elapsed.Seconds}.{ stopWatch.Elapsed.Milliseconds} ");

            stopWatch.Start();
            for (int i = 0; i < arr.Length; i++)
            {
                micList.Insert(count / 2, arr[i]);
            }
            stopWatch.Stop();

            Console.WriteLine($"Время MicrosoftList Insert { stopWatch.Elapsed.Seconds}.{ stopWatch.Elapsed.Milliseconds} ");
        }

        private static void LessonList(int count, Person[] arr)
        {
            ILessonList<Person> lessonList = new LessonList<Person>();

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            lessonList.AddRange(arr);
            stopWatch.Stop();

            Console.WriteLine($"Время LessonList AddRange  { stopWatch.Elapsed.Seconds}.{ stopWatch.Elapsed.Milliseconds} ");


            stopWatch.Start();
            for (int i = 0; i < arr.Length; i++)
            {
                lessonList.Insert(count / 2, arr[i]);
            }
            stopWatch.Stop();

            Console.WriteLine($"Время LessonList Insert { stopWatch.Elapsed.Seconds}.{ stopWatch.Elapsed.Milliseconds} ");
        }
    }
}
