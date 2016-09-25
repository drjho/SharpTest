using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpTest.Extensions
{
    public static class StringExtensions
    {
        static Random random = new Random();

        public static string Surprise(this string value)
        {
            return value + " " + random.RandomNumberString();
        }

        public static string Surprise(this string value, int seed)
        {
            return value + " " + new Random(seed).RandomNumberString();
        }

        public static string RandomNumberString(this Random random)
        {
            return random.Next(0, 101).ToString();
        }
    }
}
