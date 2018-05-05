using System;
using System.Collections.Generic;
using System.Linq;

namespace CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> filter = w => char.IsUpper(w[0]);

            Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Where(filter).ToList().ForEach(w => Console.WriteLine(w));
        }
    }
}
