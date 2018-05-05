using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();
            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                string[] nameAndAge = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                people.Add(new Person(nameAndAge[0], int.Parse(nameAndAge[1])));
            }

            string condition = Console.ReadLine();
            int ageToCompare = int.Parse(Console.ReadLine());
            string formatToPrint = Console.ReadLine();

            var filter = GetFilter(condition, ageToCompare);
            var printer = GetPrinter(formatToPrint);

            people.Where(filter).ToList().ForEach(printer);
        }

        static Func<Person, bool> GetFilter(string condition, int age)
        {
            if (condition == "older")
                return p => p.Age >= age;
            
            return p => p.Age < age;
        }

        static Action<Person> GetPrinter(string format)
        {
            if(format == "name")
                return p => Console.WriteLine(p.Name);
            else if(format == "age")
                return p => Console.WriteLine(p.Age);

            return p => Console.WriteLine($"{p.Name} - {p.Age}");
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
