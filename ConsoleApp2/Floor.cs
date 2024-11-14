using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Floor
    {
        private List<Room> _rooms;
        private int _level = 1;

        public List<Room> Rooms { get { return _rooms; } set { _rooms = value; } }
        public int Level { get { return _level; } set { _level = value; } }
        public Floor(List<Room> rooms, int level) { Rooms = rooms; Level = level; }
        public void AddRoom(Room room)
        {
            _rooms.Add(room);
        }
        public void CleareRooms()
        {
            _rooms.Clear();
        }
    }
}
