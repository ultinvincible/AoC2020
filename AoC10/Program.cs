using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC10
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"C:\Code\C#\AoC 2020\AoC10\input.txt");
            int L = input.Length + 2;
            var adapters = new int[L];
            adapters[0] = 0;
            Array.ConvertAll(input, int.Parse).CopyTo(adapters, 1);
            Array.Sort(adapters, 1, input.Length);
            adapters[^1] = adapters[^2] + 3;

            int diff1 = 0, diff3 = 0;
            for (var i = 1; i < L; i++)
            {
                if (adapters[i] - adapters[i - 1] == 1) diff1++;
                if (adapters[i] - adapters[i - 1] == 3) diff3++;
            }
            Console.WriteLine(diff1 * diff3);
            
            var pathTo = new long[L];
            pathTo[0] = 1;
            for (int i = 1; i < L; i++)
            {
                for (int j = 1; j <= 3 && i >= j; j++)
                {
                    int diff = adapters[i] - adapters[i - j];
                    if (diff >= 1 && diff <= 3)
                        pathTo[i] += pathTo[i - j];
                }
            }
            Console.WriteLine(pathTo[^1]);
        }
    }
}
