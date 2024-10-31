using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Room : LinksRooms
    {
        private int _countDoor;



        protected override Room CurrentRoom { get => this; set =>new NotImplementedException(); }
        protected override Room SecondRoom { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override Dictionary<Room, Room> LinksRoom { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
