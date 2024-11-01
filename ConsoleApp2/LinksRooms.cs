using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public abstract class LinksRooms
    {
        protected abstract Room CurrentRoom { get;}
        protected List<Room> SecondsRooms { get; set; }
        public abstract Dictionary<Room, List<Room>> LinksRoom { get; set; }


    }
}
