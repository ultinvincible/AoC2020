using System;
using System.Collections.Generic;
using System.IO;

namespace AoC1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"C:\Code\C#\AoC 2020\AoC1\input.txt");
            var numbers = new List<int>();
            foreach (string s in input)
            {
                numbers.Add(int.Parse(s));
            }

            foreach (int i in numbers)
            {
                foreach (int j in numbers)
                {
                    if (i + j == 2020)
                    {
                        Console.WriteLine(i * j);
                    }
                }
            }
            foreach (int i in numbers)
            {
                foreach (int j in numbers)
                {
                    foreach (int k in numbers)
                    {
                        if (i + j + k == 2020)
                        {
                            Console.WriteLine(i * j * k);
                        }
                    }
                }
            }
        }
    }
}