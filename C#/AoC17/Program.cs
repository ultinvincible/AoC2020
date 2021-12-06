using System;

namespace AoC17
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"../../../input.txt");
            Dimension dimension = new(input);
            for (int c = 0; c < 6; c++)
                dimension = dimension.RanCycle();

            Hyper hyper = new(input);
            Console.WriteLine(hyper.ToString());
            for (int c = 0; c < 6; c++)
            {
                hyper = hyper.RanCycle();
                Console.WriteLine("Cycle: " + c);
                Console.WriteLine(hyper.ToString());
            }
            Console.WriteLine(dimension.activeCubes);
            Console.WriteLine(hyper.activeCubes);
        }
    }
}
