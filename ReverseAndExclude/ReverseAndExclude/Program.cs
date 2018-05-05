using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse).ToList();
            int numToDivide = int.Parse(Console.ReadLine());

            Predicate<int> check = n => n % numToDivide != 0;
            Func<int, bool> isNotDivisible = n => check(n);
            Action<List<int>> printer = n => Console.WriteLine(string.Join(" ", n));

            numbers = numbers.Where(isNotDivisible).ToList();
            numbers.Reverse();
            printer(numbers);
        }
    }
}
