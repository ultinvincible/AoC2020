using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC7
{
    class Program
    {
        static void Main(string[] args)
        {
            var rules = File.ReadAllLines(
                @"C:\Code\C#\AoC 2020\AoC7\input.txt");
            var contained = new List<string>();
            int ContainerCount(string color)
            {
                int result = 0;
                foreach (var rule in rules)
                {
                    var split = rule.Split(" bags contain ");
                    if (contained.Contains(split[0]) || split[0] == color) continue;
                    var contents = split[1].Split(new[]
                            {" bags", " bag", ", ", "."},
                        StringSplitOptions.RemoveEmptyEntries);
                    foreach (var c in contents)
                    {
                        if (c[2..] == color)
                        {
                            contained.Add(split[0]);
                            result += 1 + ContainerCount(split[0]);
                        }
                    }
                }
                return result;
            }
            Console.WriteLine(ContainerCount("shiny gold"));

            int ContentsCount(string color)
            {
                int result = 0;
                foreach (var rule in rules)
                {
                    var split = rule.Split(" bags contain ");
                    if (split[0] != color || split[1] == "no other bags.") continue;
                    var contents = split[1].Split(new[]
                            {" bags", " bag", ", ", "."},
                        StringSplitOptions.RemoveEmptyEntries);
                    foreach (var c in contents)
                    {
                        result += int.Parse(c[..1]) * (1 + ContentsCount(c[2..]));
                    }

                    break;
                }
                return result;
            }
            Console.WriteLine(ContentsCount("shiny gold"));
        }
    }
}
