using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public abstract class LinksRooms
    {
        #region Fields
        private Room _currentRoom;
        private List<Room> _secondsRooms;
        private Dictionary<Room, Room> _linksRoom { get; set; }
        #endregion
        #region Properties
        public Room CurentRoom
        {
            get { return _currentRoom; }
            set { _currentRoom = value; }
        }
        public List<Room> SecondsRooms
        {
            get { return _secondsRooms; }
            set { _secondsRooms = value; }
        }
        public Dictionary<Room, Room> LinksRoom
        {
            get { return _linksRoom; }
            set { _linksRoom = value; }
        }
        #endregion
        #region Constructors
        protected LinksRooms()
        {
            LinksRoom = new Dictionary<Room, Room>();
            SecondsRooms = new List<Room>();
            CurentRoom = new Room(0, 0);
        }
        #endregion
        #region InfoMethods
        public void ShowInfo(List<Room> SecondsRooms)
        {
            foreach (var item in SecondsRooms)
            {
                Console.WriteLine($"X: {item.Coord.Item1} - Y: {item.Coord.Item2}\nCoins: {item.Coins}\nDamage: {item.Damage}");
                Console.WriteLine("");
            }
        }
        public void ShowInfo(Dictionary<Room, Room> LinksRoom)
        {
            foreach (var item in LinksRoom)
            {
                Console.WriteLine($"Key X: {item.Key.Coord.Item1} - Y: {item.Key.Coord.Item2}");
                Console.WriteLine($"Value X: {item.Value.Coord.Item1} - Y: {item.Value.Coord.Item2}");
                Console.WriteLine("");
            }
        }
        #endregion
    }
}
