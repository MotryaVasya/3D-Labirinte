using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public abstract class LinksRooms
    {
        protected abstract Room CurrentRoom { get; set; }
        protected abstract Room SecondRoom { get; set; }
        public abstract Dictionary<Room, Room> LinksRoom { get; set; }


    }
}
