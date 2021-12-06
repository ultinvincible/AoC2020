using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AoC11
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"C:\Code\C#\AoC 2020\AoC11\input.txt");
            var seats = Array.Empty<string>();
            string Adjacent(int i, int j)
            {
                var result = "";
                foreach (var x in new[] { i - 1, i, i + 1 })
                {
                    if (x >= 0 && x < seats.Length)
                        foreach (var y in new[] { j - 1, j, j + 1 })
                        {
                            if (y >= 0 && y < seats[x].Length && (x != i || y != j))
                                result += seats[x][y];
                        }
                }
                return result;
            }

            void PrintSeats(string[] seats)
            {
                for (int i = seats.Length/2-1; i <= seats.Length/2+1; i++)
                {
                    Console.WriteLine(seats[i]);
                }
                Console.WriteLine();
            }
            PrintSeats(input);

            void ApplyRules(Func<int, int, bool> rule1, Func<int, int, bool> rule2)
            {
                seats = Array.ConvertAll(input, s => s);
                List<int> toChange;
                do
                {
                    toChange = new();
                    for (int i = 0; i < seats.Length; i++)
                    {
                        for (int j = 0; j < seats[i].Length; j++)
                        {
                            if (seats[i][j] == 'L' && rule1(i, j))
                            {
                                toChange.Add(i);
                                toChange.Add(j);
                            }
                        }
                    }

                    for (int i = 0; i < toChange.Count; i++)
                    {
                        seats[toChange[i]] = new StringBuilder(seats[toChange[i]])
                        { [toChange[++i]] = '#' }.ToString();
                    }

                    PrintSeats(seats);

                    toChange = new();
                    for (int i = 0; i < seats.Length; i++)
                    {
                        for (int j = 0; j < seats[i].Length; j++)
                        {
                            if (seats[i][j] == '#' && rule2(i, j)
                                )
                            {
                                toChange.Add(i);
                                toChange.Add(j);
                            }
                        }
                    }

                    for (int i = 0; i < toChange.Count; i++)
                    {
                        seats[toChange[i]] = new StringBuilder(seats[toChange[i]])
                        { [toChange[++i]] = 'L' }.ToString();
                    }

                    PrintSeats(seats);
                } while (toChange.Count > 0);
            }
            ApplyRules((i, j) => !Adjacent(i, j).Contains('#'),
                (i, j) => Adjacent(i, j).Split('#').Length - 1 >= 4);

            int count = 0;
            foreach (var line in seats)
            {
                foreach (var seat in line)
                {
                    if (seat == '#') count++;
                }
            }
            Console.WriteLine(count);

            var directions = new[]
            { (-1,-1),(-1,0),(-1,1),(0,-1),
                    (0,1),(1,-1),(1,0),(1,1) };
            var connections=new List<(int,int,int,int)>
            string See(int i, int j)
            {
                var result = "";
                foreach (var dir in directions)
                {
                foreach (var con in connections)
                {
                    if(con.Item1==i&&con.Item2==j) 
                }
                    for (int mult = 1; ; mult++)
                    {
                        char s;
                        try { s = seats[i+dir.Item1 * mult][j+dir.Item2 * mult]; }
                        catch (IndexOutOfRangeException) { break; }
                        if (s != '.') { result += s; break; }
                    }
                }
                return result;
            }
            ApplyRules((i, j) => !See(i, j).Contains('#'),
                (i, j) => See(i, j).Split('#').Length - 1 >= 5);

            count = 0;
            foreach (var line in seats)
            {
                foreach (var seat in line)
                {
                    if (seat == '#') count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
