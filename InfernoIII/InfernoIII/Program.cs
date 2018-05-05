using System;
using System.Collections.Generic;
using System.Linq;

namespace InfernoIII
{
    class Program
    {
        public static List<Gem> gems;

        static void Main(string[] args)
        {
            gems = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                         .Select(v => new Gem(v)).ToList();
            var filtersApplied = new List<KeyValuePair<string, int>>();
            string input = Console.ReadLine();

            while (!input.Equals("Forge"))
            {
                string[] tokens = input.Split(';');
                string command = tokens[0];
                string filterType = tokens[1];
                int sum = int.Parse(tokens[2]);

                if (command == "Exclude")
                    filtersApplied.Add(new KeyValuePair<string, int>(filterType, sum));
                else
                    filtersApplied = filtersApplied.Where(f => f.Key != filterType && f.Value != sum).ToList();

                input = Console.ReadLine();
            }

            foreach (var filter in filtersApplied)
            {
                string filterType = filter.Key;
                int sum = filter.Value;

                for (int i = 0; i < gems.Count; i++)
                {
                    bool nameResponses = GetCheck(filterType, sum, i);

                    if (nameResponses)
                        gems[i].IsExcluded = true;
                }
            }

            gems.Where(g => g.IsExcluded == false).ToList().ForEach(g => Console.Write(g.Value + " "));
        }

        static bool GetCheck(string filterType, int sum, int index)
        {
            switch (filterType)
            {
                case "Sum Left":
                    if (index == 0) return gems[index].Value == sum;
                    else return gems[index].Value + gems[index - 1].Value == sum;
                case "Sum Right":
                    if (index == gems.Count - 1) return gems[index].Value == sum;
                    else return gems[index].Value + gems[index + 1].Value == sum;
                case "Sum Left Right":
                    if (gems.Count == 1) return gems[index].Value == sum;
                    else if (index == 0) return gems[index].Value + gems[index + 1].Value == sum;
                    else if (index == gems.Count - 1) return gems[index].Value + gems[index - 1].Value == sum;
                    else return gems[index].Value + gems[index - 1].Value + gems[index + 1].Value == sum;
                default:
                    return false;
            }
        }
    }

    class Gem
    {
        public int Value { get; set; }
        public bool IsExcluded { get; set; }

        public Gem(string value)
        {
            Value = int.Parse(value);
            IsExcluded = false;
        }
    }
}
