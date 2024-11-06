using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class BuildingManager
    {
        private List<Room> _rooms;
        private List<PositionRoom> _positionsRooms;
        private Random rnd;
        public BuildingManager()
        {
            _rooms = new List<Room>();
            _positionsRooms = new List<PositionRoom>();
            rnd = new Random();
        }
        public void CreateRooms(int MaxX, int MaxY, int MaxZ) // доделать генерацию комнат не квадратом
        {
            int index = 0;

            while (index != MaxX * MaxY * MaxZ)
            {
                int x = rnd.Next(0, MaxX);
                int y = rnd.Next(0, MaxY);
                int z = rnd.Next(0, MaxZ);
                foreach (var item in _positionsRooms)
                {
                }
                _positionsRooms.Add(new PositionRoom(x, y, z));
                _rooms.Add(new Room(new PositionRoom(x, y, z)));
                index++;
            }
        }
        private PositionRoom SetPositionForRoom(int MaxX, int MaxY, int MaxZ)
        {
            int x = rnd.Next(0, MaxX);
            int y = rnd.Next(0, MaxY);
            int z = rnd.Next(0, MaxZ);

            PositionRoom positionRoom = new PositionRoom(x, y, z);
            
            if (_positionsRooms.Contains(positionRoom))
            {
                positionRoom = new PositionRoom
                    (
                    x += rnd.Next(x >= 1 ? x - 1 : 0, x + 1),
                    y += rnd.Next(y >= 1 ? y - 1 : 0, y + 1),
                    z += rnd.Next(z >= 1 ? z - 1 : 0, z + 1)
                    );

            }

            return positionRoom;
        }
        public void ShowInfo()
        {
            foreach (var item in _rooms)
            {
                Console.WriteLine($"{item.Position.Z} - {item.Position.X} - {item.Position.Y}");
            }
        }

    }
}
