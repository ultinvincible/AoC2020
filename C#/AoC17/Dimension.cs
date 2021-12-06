using System;
using System.Collections.Generic;

namespace AoC17
{
    class Cube
    {
        public bool active;
        public int activeNeighbors;

        public Cube(bool a = false, int an = 0)
        {
            active = a;
            activeNeighbors = an;
        }
        public override string ToString()
        //=> active.ToString()[0] + " | N = " + activeNeighbors;
        {
            string result = "";
            if (active) result += "#";
            else result += ".";
            if (activeNeighbors >= 0)
                result += activeNeighbors.ToString(" 00");
            else result += activeNeighbors.ToString("00");
            return result + "|";
        }
    }
    class Dimension : List<List<List<Cube>>>
    {
        public int activeCubes;
        List<Cube> NewLine()
        {
            List<Cube> newList = new();
            for (int i = 0; i < this[0][0].Count; i++)
                newList.Add(new Cube());
            return newList;
        }
        public List<List<Cube>> NewSurface()
        {
            List<List<Cube>> newSurface = new();
            for (int i = 0; i < this[0].Count; i++)
                newSurface.Add(NewLine());
            return newSurface;
        }
        public Dimension(string[] input)
        {
            activeCubes = 0;
            Add(new List<List<Cube>>());
            for (int i = 0; i < input.Length + 2; i++)
            {
                this[0].Add(new());
                for (int j = 0; j < input[0].Length + 2; j++)
                    this[0][i].Add(new());
            }
            Add(NewSurface());

            for (int i = 0; i < input.Length; i++)
                for (int j = 0; j < input[i].Length; j++)
                    if (input[i][j] == '#')
                        SetCube(0, i + 1, j + 1, true);
        }
        public Dimension(Dimension original)
        {
            activeCubes = original.activeCubes;
            for (int z = 0; z < original.Count; z++)
            {
                Add(new());
                for (int y = 0; y < original[z].Count; y++)
                {
                    this[z].Add(new());
                    for (int x = 0; x < original[z][y].Count; x++)
                        this[z][y].Add(new Cube(original[z][y][x].active,
                            original[z][y][x].activeNeighbors));
                }
            }
        }
        public Dimension() { }
        public Cube GetCube(params int[] zyx)
            => this[zyx[0]][zyx[1]][zyx[2]];
        public void Extend()
        {
            foreach (var surface in this)
            {
                foreach (var line in surface)
                {
                    line.Insert(0, new());
                    line.Add(new());
                }
                surface.Insert(0, NewLine());
                surface.Add(NewLine());
            }
            Add(NewSurface());
        }
        public int[][] Neighbors(int z, int y, int x)
        {
            int[][] neis = new int[26][];
            int[] bounds = { Count, this[0].Count, this[0][0].Count };
            int i = 0;
            for (int neiZ = z - 1; neiZ <= z + 1; neiZ++)
                for (int neiY = y - 1; neiY <= y + 1; neiY++)
                    for (int neiX = x - 1; neiX <= x + 1; neiX++)
                    {
                        int[] nei = { neiZ, neiY, neiX };
                        if ((neiZ, neiY, neiX) != (z, y, x) && //exclude self
                            Array.TrueForAll(new int[] { 0, 1, 2 },
                            j => nei[j] >= 0 && nei[j] < bounds[j])) //bounds check
                            neis[i++] = nei;
                    }
            return neis[..i];
        }
        public void SetCube(int z, int y, int x, bool active)
        {
            GetCube(z, y, x).active = active;
            int add = Convert.ToInt32(active) * 2 - 1;//true=>1,false=>-1
            if (z == 0)
                activeCubes += add;
            else activeCubes += 2 * add; //active cubes count

            foreach (int[] zyx in Neighbors(z, y, x)) //neighbors
            {
                int a = add;
                if (z != 0 && zyx[0] == 0)
                    a *= 2;
                GetCube(zyx).activeNeighbors += a; //nei
            }
        }
        public Dimension RanCycle(bool debug = false)
        {
            Extend();
            Dimension newDimension = new(this);

            for (int z = 0; z < Count; z++)
                for (int y = 0; y < this[z].Count; y++)
                    for (int x = 0; x < this[z][y].Count; x++)
                    {
                        Cube current = GetCube(z, y, x);
                        bool active = current.active;
                        int neiAct = current.activeNeighbors;

                        if ((active && neiAct != 2 && neiAct != 3) ||
                            (!active && neiAct == 3))
                            newDimension.SetCube(z, y, x, !active);
                        //Console.Clear();
                        //Console.Write(ToString()+"\n"+ newDimension.ToString());
                    }
            return newDimension;
        }
        public override string ToString()
        {
            string result = "";
            for (int z = 0; z < Count; z++)
            {
                result += "z=" + z + "\n";
                foreach (var line in this[z].GetRange(0, this[z].Count))
                {
                    foreach (var cube in line.GetRange(0, line.Count))
                        result += cube;
                    result += "\n";
                }
                result += "\n";
            }
            return result;
        }
    }
}
