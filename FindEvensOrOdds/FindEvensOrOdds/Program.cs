using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bounds = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                             .Select(int.Parse).ToArray();

            int lowerBound = bounds[0];
            int upperBound = bounds[1];

            if(lowerBound > upperBound)
            {
                int temp = lowerBound;
                lowerBound = upperBound;
                upperBound = temp;
            }

            string typeNumbersWanted = Console.ReadLine();

            Predicate<int> check = GetCheck(typeNumbersWanted);
            Action<int> printer = n => Console.Write(n + " ");

            for (int num = lowerBound; num <= upperBound; num++)
            {
                if(check(num))
                    printer(num);
            }
        }

        static Predicate<int> GetCheck(string typeNumbersWanted)
        {
            if (typeNumbersWanted == "odd")
                return n => n % 2 == 1 || n % 2 == -1;

            return n => n % 2 == 0;
        }
    }
}
