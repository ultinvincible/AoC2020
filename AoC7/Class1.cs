using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC7
{
    class Color
    {
        private string name;
        private List<Color> containers;

        public Color(string _name, params Color[] _containers)
        {
            name = _name;
            containers = new List<Color>(_containers);
        }
    }
}
