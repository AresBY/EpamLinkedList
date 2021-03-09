using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.LinkedList.UnitTests
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskTest tt = new TaskTest();
            tt.Add_Should_Return_Changed_List();
            tt.AddRange_Should_Return_Changed_List();
            tt.Insert_Should_Return_Changed_List();
            tt.Clear_Should_Return_Clear_List();
            tt.Contains_Should_Return_True_or_False();
            tt.CopyTo_Should_Return_Changed_List();
            tt.Remove_Should_Return_Changed_List();
            tt.RemoveAt_Should_Return_Changed_List();
            Console.ReadKey();
        }
    }
}
