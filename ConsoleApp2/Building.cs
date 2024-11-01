using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Building
    {
        private List<Room> _rooms;
        public List<Room> Rooms
        {
            get { return _rooms; }
            set { _rooms = value; }
        }
    }
}
