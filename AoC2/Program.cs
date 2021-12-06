using System;
using System.IO;

namespace AoC2
{
    class Program
    {
        static void Main(string[] args)
        {
            var entries = File.ReadAllLines(@"C:\Code\C#\AoC 2020\AoC2\input.txt");
            int valid1 = 0, valid2 = 0;
            foreach (string ent in entries)
            {
                var details = ent.Split(':')[0].Trim();
                var password = ent.Split(':')[1].Trim();
                var chars = details.Split(new char[] { '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int min = int.Parse(chars[0]), max = int.Parse(chars[1]), appear = 0, match = 0;

                foreach (char c in password)
                {
                    if (c.ToString() == chars[2]) appear++;
                }
                if (appear >= min && appear <= max) { valid1++; Console.Write("v1 "); }

                if (password[min - 1].ToString() == chars[2]) match++;
                if (password[max - 1].ToString() == chars[2]) match++;
                if (match == 1) { valid2++; Console.Write("v2 "); }

                //Console.WriteLine(chars[0] + ";" + appear + ";" + chars[1] + " ");
                //Console.WriteLine(details);
                //Console.WriteLine(password);
            }
            Console.WriteLine("Valid1: " + valid1+"; Valid2: " + valid2);
        }
    }
}
