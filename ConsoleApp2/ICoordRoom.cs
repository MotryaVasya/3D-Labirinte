using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public interface ICoordRoom
    {
        (int, int) CurentCoord { get; set; }
        List<(int, int)> RoomsCoords { get; set; }
        
    }
}
