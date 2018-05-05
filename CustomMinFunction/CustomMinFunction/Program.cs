using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse).ToList();

            Func<List<int>, int> minNumberFunc = GetMinNumber;
            int minNumber = minNumberFunc(numbers);

            Console.WriteLine(minNumber);
        }

        static int GetMinNumber(List<int> numbers)
        {
            int min = int.MaxValue;

            foreach (int num in numbers)
            {
                if (min > num)
                    min = num;
            }

            return min;
        }
    }
}
