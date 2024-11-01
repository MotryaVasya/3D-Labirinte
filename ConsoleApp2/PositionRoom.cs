using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class PositionRoom
    {
        private int _x;
        private int _y;
        private int _z;
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public int Z { get => _z; set => _z = value; }
        public PositionRoom(int x, int y, int z) { X = x; Y = y; Z = z; }
    }
}
