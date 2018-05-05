using System;
using System.Collections.Generic;
using System.Linq;

namespace AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                              .Select(n => double.Parse(n, System.Globalization.CultureInfo.InvariantCulture))
                              .Select(n => n * 1.2)
                              .ToList()
                              .ForEach(n => Console.WriteLine($"{n:F2}"));
        }
    }
}
