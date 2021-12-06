using System;
using System.IO;

namespace AoC3
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = File.ReadAllLines(@"C:\Code\C#\AoC 2020\AoC3\input.txt");
            var columnsCount = rows[0].Length;
            long countTrees(int right, int down)
            {
                long trees = 0; int x = 0;
                for (int i = 0; i < rows.Length; i += down)
                {
                    if (rows[i][x % columnsCount] == '#') trees++;
                    x += right;
                }
                Console.WriteLine("Trees(" + right + "," + down + "): " + trees);
                return trees;
            }
            Console.WriteLine(countTrees(1, 1) * countTrees(3, 1)
                * countTrees(5, 1) * countTrees(7, 1) * countTrees(1, 2));
        }
    }
}
