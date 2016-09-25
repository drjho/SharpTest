using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AysncTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() => Caller()).Wait();
            FirstTaskAsync().Wait();
        }

        static async Task Caller()
        {
            var t1 = FirstTaskAsync();
            var t2 = SecondTaskAsync();

            await Task.WhenAll(t1, t2);

            Console.WriteLine("All Finíshed");
        }

        static async Task FirstTaskAsync()
        {
            Console.WriteLine("1st task, 10 sec");
            await Task.Delay(10000);
            Console.WriteLine("1st task finished");
        }

        static async Task SecondTaskAsync()
        {
            Console.WriteLine("2nd task, 5 sec");
            await Task.Delay(5000);
            Console.WriteLine("2nd task finished");
        }
    }
}
