using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class BuildingManager : Random
    {
        private List<Room> _rooms;
        public BuildingManager()
        {
            _rooms = new List<Room>();
        }
        public void CreateRooms(int MaxX, int MaxY, int MaxZ) // доделать генерацию комнат не квадратом
        {
            for (int i = 0; i < MaxX; i++)
            {
                for (int j = 0; j < MaxY; j++)
                {
                    for (int k = 0; k < MaxZ; k++)
                    {
                        _rooms.Add(new Room(new PositionRoom(i, j, k)));
                    }
                }
            }
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
