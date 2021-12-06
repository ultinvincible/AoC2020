using System;
using System.IO;
using System.Text.RegularExpressions;

namespace AoC4
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText(@"C:\Code\C#\AoC 2020\AoC4\input.txt");
            var pps = input.Split("\n\n");
            string[] req = new string[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
            Predicate<string>[] form = new Predicate<string>[]
            {
                s=> int.TryParse(s,out int i) &&  i >= 1920 && i <= 2002,
                s=> int.TryParse(s,out int i) &&  i >= 2010 && i <= 2020,
                s=> int.TryParse(s,out int i) &&  i >= 2020 && i <= 2030,
                s=> {if (!int.TryParse(s.Substring(0,s.Length-2),
                    out int i)&&s.Length<4) return false;
                    else if(s.Substring(s.Length-2,2)=="cm")
                        return i>=150&&i<=193;
                    else if(s.Substring(s.Length-2,2)=="in")
                        return i>=59&&i<=76;
                    else return false; },
                s=> s[0]=='#'&&s.Length==7&&
                    Regex.IsMatch(s, @"#\b[0-9a-f]+\b\Z"),
                s=>Array.IndexOf(new string[]{"amb","blu","brn","gry","grn","hzl","oth" },s)>= 0,
                s=>s.Length==9&&int.TryParse(s,out int i)
            };
            int valid1 = 0, valid2 = 0;
            foreach (string pp in pps)
            {
                int match = 0; bool matchForm = true;
                var split = pp.Split(new char[] { ':', ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < split.Length; i++)
                {
                    int ind = Array.IndexOf(req, split[i]);
                    if (ind >= 0)
                    {
                        match++;
                        if (!form[ind](split[i + 1])) matchForm = false;
                        i++;
                    }
                }
                if (match == req.Length) valid1++;
                if (match == req.Length && matchForm) valid2++;
            }
            Console.WriteLine(valid1 + ";" + valid2);
        }
    }
}
