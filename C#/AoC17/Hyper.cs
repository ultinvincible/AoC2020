using System;
using System.Collections.Generic;

namespace AoC17
{
    class Hyper : List<Dimension>
    {
        public int activeCubes;
        Dimension NewDimension()
        {
            Dimension newDimension = new();
            for (int i = 0; i < this[0].Count; i++)
                newDimension.Add(this[0].NewSurface());
            return newDimension;
        }
        public Hyper(string[] input)
        {
            activeCubes = 0;
            Add(new Dimension());
            this[0].Add(new());
            for (int i = 0; i < input.Length + 2; i++)
            {
                this[0][0].Add(new());
                for (int j = 0; j < input[0].Length + 2; j++)
                    this[0][0][i].Add(new());
            }
            this[0].Add(this[0].NewSurface());
            Add(NewDimension());

            for (int i = 0; i < input.Length; i++)
                for (int j = 0; j < input[i].Length; j++)
                    if (input[i][j] == '#')
                        SetCube(0, 0, i + 1, j + 1, true);
        }
        public Hyper(Hyper source)
        {
            activeCubes = source.activeCubes;
            for (int w = 0; w < source.Count; w++)
                Add(new Dimension(source[w]));
        }
        public Cube GetCube(int[] wzyx)
            => this[wzyx[0]][wzyx[1]][wzyx[2]][wzyx[3]];
        public int[][] Neighbors(int w, int z, int y, int x)
        {
            int[][] neis = new int[80][];
            int i = 0;
            for (int neiW = w - 1; neiW <= w + 1; neiW++)
                foreach (var zyx in this[w].Neighbors(z, y, x))
                    if ((neiW, zyx[0], zyx[1], zyx[2]) != (w, z, y, x) && //exclude self
                        neiW >= 0 && neiW < Count) //bounds check
                        neis[i++] = new int[] { neiW, zyx[0], zyx[1], zyx[2] };
            return neis[..i];
        }
        static int Add(bool active, bool w, bool z) //SetCube use
        {
            int add = Convert.ToInt32(active) * 2 - 1;//true=>1,false=>-1
            if (w && z)
                return 4 * add;
            else if (w || z)
                return 2 * add;
            else return add;
        }
        public void SetCube(int w, int z, int y, int x, bool active)
        {
            GetCube(new int[] { w, z, y, x }).active = active;
            activeCubes += Add(active, w != 0, z != 0);

            var neis = Neighbors(w, z, y, x);
            foreach (var wzyx in neis)
                GetCube(wzyx).activeNeighbors +=
                    Add(active, w != 0 && wzyx[0] == 0, z != 0 && wzyx[1] == 0);
        }
        public Hyper RanCycle()
        {
            for (int w = 0; w < Count; w++)
                this[w].Extend();
            Add(NewDimension());
            Hyper newHyper = new(this);

            for (int w = 0; w < Count; w++)
                for (int z = 0; z < this[w].Count; z++)
                    for (int y = 0; y < this[w][z].Count; y++)
                        for (int x = 0; x < this[w][z][y].Count; x++)
                        {
                            Cube current = GetCube(new int[] { w, z, y, x });
                            bool active = current.active;
                            int neiAct = current.activeNeighbors;

                            if ((active && neiAct != 2 && neiAct != 3) ||
                                (!active && neiAct == 3))
                                newHyper.SetCube(w, z, y, x, !active);
                            //Console.Clear();
                            //Console.Write(newHyper.ToString());
                        }
            return newHyper;
        }
        public override string ToString()
        {
            string result = "";
            for (int w = 0; w < Count; w++)
                result += "w=" + w + ": " + this[w].ToString();
            return result;
        }
    }
}
