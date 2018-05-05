using System;
using System.Collections.Generic;
using System.Linq;

namespace ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printer = n => Console.WriteLine(n);

            Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                              .ToList().ForEach(printer);
        }
    }
}
