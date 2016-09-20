using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var g = new MyGenericClass<TempClass>();
            var v = ChangeType<string, int>("10");
        }
        static T2 ChangeType<T1, T2>(T1 value) where T2 : new()
        {
            return (T2)Convert.ChangeType(value, typeof(T2));
        }
    }

    public class MyGenericClass<T> where T : IComparable, new() { }

    public class TempClass : IComparable
    {
        public int CompareTo(object obj)
        {
            return 0;
        }
    }

}
