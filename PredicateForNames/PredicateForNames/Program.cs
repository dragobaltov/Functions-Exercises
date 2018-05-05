using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxLength = int.Parse(Console.ReadLine());
            Predicate<int> predicate = n => n <= maxLength;
            Action<string> printer = n => Console.WriteLine(n);

            Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                              .Where(n => predicate(n.Length)).ToList().ForEach(printer);
        }
    }
}
