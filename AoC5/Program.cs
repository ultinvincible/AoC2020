using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace AoC5
{
    class Program
    {
        static void Main(string[] args)
        {
            var passes = File.ReadAllLines(@"C:\Code\C#\AoC 2020\AoC5\input.txt");
            int max = 0; var ids = new List<int>();
            for (var i = 0; i < passes.Length; i++)
            {
                string row = "", column = "";
                for (int j = 0; j < 7; j++)
                {
                    if (passes[i][j] == 'F') row += '0';
                    if (passes[i][j] == 'B') row += '1';
                }

                for (int j = 0; j < 3; j++)
                {
                    if (passes[i][j + 7] == 'L') column += '0';
                    if (passes[i][j + 7] == 'R') column += '1';
                }

                int id = Convert.ToInt32(row, 2) * 8
                         + Convert.ToInt32(column, 2);
                if (max < id) max = id;
                ids.Add(id);
            }
            Console.WriteLine(max);
            var range = Enumerable.Range(0, max);
            foreach (int i in range)
                if (!ids.Contains(i) && ids.Contains(i + 1) && ids.Contains(i - 1))
                    Console.WriteLine(i);
        }
    }
}
