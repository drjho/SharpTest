using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest
{
    class Car
    {
        public string Model { get; set; }
        public int Doors { get; set; }
    }

    static class CarExtension
    {
        public static void Print(this Car car)
        {
            Console.WriteLine(car.Model + "; doors: " + car.Doors);
        }

        public static void Print(this string str)
        {
            Console.WriteLine(str);
        }
    }

    static class ListExtension
    {
        public static void Print<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (T item in list)
            {
                action(item);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>
            {
                new Car {Model = "Saab", Doors = 5 },
                new Car {Model = "Volvo", Doors = 5 },
                new Car {Model = "Porsche", Doors = 3 }
            };

            var cars1 = cars.Where(c => c.Doors > 4);
            var cars2 = cars.OrderBy(c => c.Model).ThenBy(c => c.Doors);
            var cars3 = from car in cars
                        orderby car.Model, car.Doors
                        select car;
            var doors = cars.Select(c => c.Doors);
            var volvo = cars.Find(c => c.Model == "Volvo");
            "the volvo:".Print();
            volvo.Print();

            var count = cars.Count(c => c.Doors > 4);

            Console.WriteLine("cars1");
            foreach (var item in cars1)
            {
                item.Print();
            }
            Console.WriteLine("cars3");
            foreach (var item in cars3)
            {
                item.Print();
            }

            doors.Print(d => { Console.WriteLine(d); });

            Console.WriteLine("count for cars with more than 4 doors: " + count);
        }
    }
}
