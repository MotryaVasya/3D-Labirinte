using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class BuildingManager
    {
        private Floor _floor;
        private int[,] _positionsRooms;
        private List<Floor> _floors;
        private Random rnd;


        public BuildingManager()
        {
            _floors = new List<Floor>();
            _floor = new Floor(new List<Room>(), 0);
            rnd = new Random();

        }
        public void CreateRooms(int MaxX, int MaxY) // доделать генерацию комнат не квадратом
        {
            int index = 0;

            while (index != MaxX * MaxY - 20)
            {
                var room = SetPositionForRoom(MaxX, MaxY);
                _floor.AddRoom(room);
                index++;
            }
            _floors.Add(_floor);
        }

        private Room SetPositionForRoom(int MaxX, int MaxY)
        {
            int x = rnd.Next(0, MaxX);
            int y = rnd.Next(0, MaxY);

            foreach (var item in _floor.Rooms)
            {
                if (item.IndexX == x && item.IndexY == y)
                {
                    x += rnd.Next(
                        x >= 1 ? x - 1 : 0,
                        x >= MaxX ? x - 1 : x + 1);
                    y += rnd.Next(
                        y >= 1 ? y - 1 : 0,
                        y >= MaxY ? y - 1 : y + 1);
                    return new Room(x,y);
                }
            }


            return new Room(x,y);
        }
        public void ShowInfo()
        {
            foreach (var item in _floors)
            {
                foreach (var item1 in item.Rooms)
                {
                    Console.WriteLine($"{item1.IndexX} - {item1.IndexY}");
                }
            }
        }

    }
}
