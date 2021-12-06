using System;
using System.Collections.Generic;
using System.IO;

namespace AoC8
{
    class Program
    {
        static void Main(string[] args)
        {
            var instructions = File.ReadAllLines(
                @"C:\Code\C#\AoC 2020\AoC8\input.txt");
            int line = 0, accumulator = 0,max=0;
            var passed = new List<int>();
            while (!passed.Contains(line))
            {
                passed.Add(line);
                var split = instructions[line].Split(' ');
                switch (split[0])
                {
                    case "acc":
                        accumulator += int.Parse(split[1]);
                        line++;
                        break;
                    case "jmp":
                        line += int.Parse(split[1]);
                        break;
                    case "nop":
                        line++;
                        break;
                }

                if (max < line) max = line;
            }
            Console.WriteLine("Part 1: " + accumulator/*+";"+max+"/"+instructions.Length*/);

            max = 0;
            for (var i = 0; i < instructions.Length; i++)
            {
                var instruction = instructions[i].Split(' ')[0];
                if (instruction != "acc")
                {
                    line = 0; accumulator = 0;
                    passed = new List<int>();
                    while (!passed.Contains(line))
                    {
                        //if (i==266) Console.WriteLine(line);
                        passed.Add(line);
                        var split = instructions[line].Split(' ');
                        var instr = split[0];
                        if (line == i)
                        {
                            if (instr == "jmp") instr = "nop";
                            else if (instr == "nop") instr = "jmp";
                        }
                        switch (instr)
                        {
                            case "acc":
                                accumulator += int.Parse(split[1]);
                                line++;
                                break;
                            case "jmp":
                                line += int.Parse(split[1]);
                                break;
                            case "nop":
                                line++;
                                break;
                        }

                        if (max < line) max = line;
                        if (line < instructions.Length) continue;
                        Console.WriteLine("Part 2: " + accumulator/*+";"+i*/);
                        break;
                    }
                }
            }
            //Console.WriteLine(max + "/" + instructions.Length);
        }
    }
}
