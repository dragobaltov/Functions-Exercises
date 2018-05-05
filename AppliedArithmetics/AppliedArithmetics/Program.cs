using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse).ToList();
            string command = Console.ReadLine();

            Action<List<int>> printer = n => Console.WriteLine(string.Join(" ", n));
            Func<int, int> currentFunc;

            while (!command.Equals("end"))
            {
                if (command == "print")
                {
                    printer(numbers);
                }
                else
                {
                    currentFunc = GetFunc(command);
                    numbers = numbers.Select(currentFunc).ToList();
                }

                command = Console.ReadLine();
            }
        }

        static Func<int, int> GetFunc(string command)
        {
            if (command == "add")
                return n => n + 1;
            else if (command == "subtract")
                return n => n - 1;

            return n => n * 2;
        }
    }
}
