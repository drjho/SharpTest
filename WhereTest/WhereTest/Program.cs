using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpTest.Extensions;

namespace SharpTest
{
    class Program
    {
        delegate int UserIntCallBack(int i);

        static void Main(string[] args)
        {
            int? nullableInt = null;

            Nullable<int> nInt = null;

            Console.WriteLine( $"NullableInt value: {nullableInt}");

            nInt = 1;

            Console.WriteLine( nInt );

            var g = new MyGenericClass<TempClass>();
            var v = ChangeType<string, int>("10");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("test string".Surprise(i));
            }

            var o = new { Name = "test", i = 20 };

            Console.WriteLine(o);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("test string".Surprise());
            }

            Console.WriteLine(MathFunction(10, (i) => { return i + 100; }));
            Console.WriteLine(MathFunction(10, (i) => { return i - 100; }));

            AnotherAction(33, (i) => Console.WriteLine(i));

            Console.WriteLine(AnotherFunc(22, (a,b) => a * b )); // samma som Console.WriteLine(AnotherFunc(22, (a,b) => { return a * b; } )); Med return måste man ha måsvingar.

            // Kolla hur det fungerar med index i lambda-exp.
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var firstSmallNumbers = numbers.TakeWhile((n, index) => n >= index);

            foreach (var item in firstSmallNumbers)
            {
                Console.WriteLine(item);
            }
        }

        static float AnotherFunc(int i, Func<int, int, float> function)
        {
            return function(i, i);
        }

        static void AnotherAction(int i, Action<int> action)
        {
            action(i);
        }

        static int MathFunction(int i, UserIntCallBack callback)
        {
            return callback(i);
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
