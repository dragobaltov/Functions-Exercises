using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty_
{
    class Program
    {
        public static List<Guest> guests;

        static void Main(string[] args)
        {
            guests = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(n => new Guest(n)).ToList();
            string command = Console.ReadLine();

            while (!command.Equals("Party!"))
            {
                guests = GetNewList(command);

                command = Console.ReadLine();
            }

            if (guests.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                for (int i = 0; i < guests.Count; i++)
                {
                    for (int j = 0; j < guests[i].Count; j++)
                    {
                        if(i == guests.Count - 1 && j == guests[i].Count - 1)
                            Console.Write(guests[i].Name + " ");
                        else
                            Console.Write(guests[i].Name + ", ");
                    }
                }

                Console.Write("are going to the party!");
            }
        }

        static List<Guest> GetNewList(string command)
        {
            string[] tokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string action = tokens[0];
            string condition = tokens[1];
            string parameter = tokens[2];
            Func<string, bool> nameResponses = GetFunc(condition, parameter);

            if (action == "Double")
            {
                foreach (Guest guest in guests)
                {
                    if (nameResponses(guest.Name))
                    {
                        guest.Count *= 2;
                    }
                }
            }
            else
            {
                foreach (Guest guest in guests)
                {
                    if (nameResponses(guest.Name))
                    {
                        guest.Count = 0;
                    }
                }

                guests = guests.Where(g => g.Count > 0).ToList();
            }

            return guests;
        }

        static Func<string, bool> GetFunc(string condition, string parameter)
        {
            if (condition == "StartsWith")
            {
                return n => n.Length >= parameter.Length ? n.Substring(0, parameter.Length) == parameter : false;
            }
            else if (condition == "EndsWith")
            {
                return n => n.Length >= parameter.Length ? n.Substring(n.Length - parameter.Length) == parameter : false;
            }
            else
            {
                int length = int.Parse(parameter);

                return n => n.Length == length;
            }
        }
    }

    class Guest
    {
        public string Name { get; set; }
        public int Count { get; set; }

        public Guest(string name)
        {
            Name = name;
            Count = 1;
        }
    }
}
