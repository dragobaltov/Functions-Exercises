using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int upperBound = int.Parse(Console.ReadLine());
            var dividers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                             .Select(int.Parse).ToList();

            Action<int> printer = n => Console.Write(n + " ");
            var predicates = dividers.Select(d => (Func<int, bool>)(n => n % d == 0)).ToList();

            for (int i = 1; i <= upperBound; i++)
            {
                if (GetCheck(i, predicates))
                    printer(i);
            }
        }

        static bool GetCheck(int number, List<Func<int, bool>> predicates)
        {
            foreach (var predicate in predicates)
            {
                if (!predicate(number))
                    return false;
            }

            return true;
        }
    }
}
