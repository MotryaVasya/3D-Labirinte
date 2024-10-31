using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Room : LinksRooms
    {
        private Position _position;

        public Position Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public void SetPosition(int x, int y, int z)
        {
            if (Position.Locked == false)
            {
                Position.X = x;
                Position.Y = y;
                Position.Z = z;
                Position.Locked = true;
                return;
            }
            Console.WriteLine("такая комната уже существует");
        }

        protected override Room CurrentRoom { get => this;}
        protected override List<Room> SecondsRooms { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override Dictionary<Room, List<Room>> LinksRoom { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Room(Position position)
        {
            _position = position;
        }
    }
}
