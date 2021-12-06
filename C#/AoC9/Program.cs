using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC9
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(
                @"C:\Code\C#\AoC 2020\AoC9\input.txt");
            var numbers = new long[input.Length];
            long answer = 0;
            for (var i = 0; i < input.Length; i++)
            {
                numbers[i] = long.Parse(input[i]);
            }

            for (var i = 25; i < numbers.Length; i++)
            {
                var pre = numbers.Skip(i - 25).Take(25);
                bool wrong = true;
                foreach (long j in pre)
                {
                    if (pre.Contains(numbers[i] - j))
                        wrong = false;
                }

                if (wrong)
                {
                    answer = numbers[i];
                    Console.WriteLine(answer);
                    break;
                }
            }

            for (var i = 0; i < numbers.Length; i++)
            {
                long sum = numbers[i];
                int j = 0;
                while (sum < answer && i + ++j < numbers.Length)
                {
                    sum += numbers[i + j];
                    if (sum == answer && j != 0)
                    {
                        var x = numbers.Skip(i).Take(j).ToArray();
                        var y = x.Max() + x.Min();
                        Console.WriteLine(y +"|i= " + i + ";j= " + j);
                    }
                }
            }
        }
    }
}
