using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class LinksRooms
    {
        #region Fields
        private static Room _currentRoom;
        private static List<Room> _secondsRooms;
        private static Dictionary<Room, List<Room>> _linksRoom { get; set; }
        #endregion
        #region Properties
        public static Room CurrentRoom
        {
            get { return _currentRoom; }
            set { _currentRoom = value; }
        }
        public static List<Room> SecondsRooms 
        {
            get { return _secondsRooms; }
            set { _secondsRooms = value; }
        }
        public static Dictionary<Room, List<Room>> LinksRoom
        {
            get { return _linksRoom; }
            set { _linksRoom = value; }
        }
        #endregion

    }
}
