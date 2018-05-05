using System;
using System.Collections.Generic;
using System.Linq;

namespace PartyReservationFilterModule
{
    class Program
    {
        public static List<Guest> guests;
        public static List<KeyValuePair<string, string>> filtersApplied;

        static void Main(string[] args)
        {
            guests = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                           .Select(n => new Guest(n)).ToList();
            filtersApplied = new List<KeyValuePair<string, string>>();
            string input = Console.ReadLine();

            while (!input.Equals("Print"))
            {
                ChangeList(input);

                input = Console.ReadLine();
            }

            guests.Where(g => g.IsComing == true).ToList().ForEach(g => Console.Write(g.Name + " "));
        }

        static void ChangeList(string input)
        {
            string[] tokens = input.Split(';');
            string command = tokens[0];
            string filterType = tokens[1];
            string parameter = tokens[2];
            Func<string, bool> nameResponse = GetCheck(filterType, parameter);

            if(command == "Add filter")
            {
                foreach (var guest in guests.Where(g => g.IsComing == true))
                {
                    if (nameResponse(guest.Name))
                        guest.IsComing = false;
                }

                filtersApplied.Add(new KeyValuePair<string, string>(filterType, parameter));
            }
            else
            {
                foreach (var guest in guests.Where(g => g.IsComing == false))
                {
                    if (nameResponse(guest.Name))
                        if (FiltersAreNotAppliedOnGuest(guest.Name, filterType, parameter))
                            guest.IsComing = true;
                }

                filtersApplied = filtersApplied.Where(f => f.Key != filterType && f.Value != parameter).ToList();
            }
        }

        static bool FiltersAreNotAppliedOnGuest(string name, string currentFilterType, string currentParameter)
        {
            Func<string, bool> nameResponse = null;

            foreach (var filter in filtersApplied.Where(f => f.Key != currentFilterType && f.Value != currentParameter))
            {
                nameResponse = GetCheck(filter.Key, filter.Value);

                if (nameResponse(name))
                    return false;
            }

            return true;
        }

        static Func<string, bool> GetCheck(string filterType, string parameter)
        {
            switch (filterType)
            {
                case "Starts with":
                    return n => n.Length >= parameter.Length ? n.Substring(0, parameter.Length) == parameter : false;
                case "Ends with":
                    return n => n.Length >= parameter.Length ? n.Substring(n.Length - parameter.Length) == parameter : false;
                case "Contains":
                    return n => n.Contains(parameter);
                case "Length":
                    int length = int.Parse(parameter);
                    return n => n.Length == length;
                default:
                    return null;
            }
        }
    }

    class Guest
    {
        public string Name { get; set; }
        public bool IsComing { get; set; }

        public Guest(string name)
        {
            Name = name;
            IsComing = true;
        }
    }
}
