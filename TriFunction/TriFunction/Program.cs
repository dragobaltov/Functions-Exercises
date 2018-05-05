using System;
using System.Collections.Generic;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var filter = GetFilter(sum);

            Console.WriteLine(names.FirstOrDefault(filter));
        }

        static Func<string, bool> GetFilter(int sum)
        {
            return n => n.ToCharArray().Sum(c => c) >= sum;
        }
    }
}
