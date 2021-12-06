using System;
using System.IO;
using System.Linq;

namespace AoC6
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText(@"C:\Code\C#\AoC 2020\AoC6\input.txt");
            var groups = input.Split("\n\n");

            int sum1 = 0, sum2 = 0;
            foreach (var group in groups)
            {
                var unique = group.Replace("\n",
                    "").Distinct().ToList();
                var indivs = group.Split('\n',StringSplitOptions.RemoveEmptyEntries);
                var all = unique.ConvertAll(c => c);
                sum1 += unique.Count;
                foreach (char c in unique) foreach (var indiv in indivs)
                    {
                        Console.WriteLine(indiv+";"+c);
                        if (!indiv.Contains(c)) all.Remove(c);
                    }
                sum2 += all.Count;
            }
            Console.Write(sum1 + ";" + sum2);
        }
    }
}
