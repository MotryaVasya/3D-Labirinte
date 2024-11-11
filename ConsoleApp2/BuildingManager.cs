using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class BuildingManager
    {
        #region Fields
        private Floor _floor;
        private List<Floor> _floors;
        static private Random rnd;
        #endregion
        #region Constructors
        public BuildingManager()
        {
            _floors = new List<Floor>();
            _floor = new Floor(new List<Room>(), 0);
            rnd = new Random();

        }

        #endregion
        public void CreateRooms(int MaxX, int MaxY) // доделать генерацию комнат 
        {
            int max = MaxX * MaxY - 20;
            Room room;
            int r;

            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < max; j++)
                {
                    room = new Room(i, j, rnd.Next(3), rnd.Next(0, 5) == 1);
                    LinksRooms.SecondsRooms.Add(room);
                    if (i == 0 && j == 0)
                    {
                        r = rnd.Next(1, 2);// 1 = вверх | 2 = вправо
                    }
                    if (i == 0 && j == MaxY)
                    {
                        r = rnd.Next(-1, 1);
                        while (r == 0)
                        {
                            r = rnd.Next(-1, 1);
                        }
                    }
                    if (i == MaxX && j == 0)
                    {
                        r = rnd.Next(1, 2);// 1 = вниз | 2 = вправо

                    }
                    if (true) // доделать if
                    {

                    }
                    _floor.AddRoom(room);
                }

            }
            _floors.Add(_floor);
        }

        private void SetLincsForRoom(int MaxX, int MaxY)
        {

            for (int i = 0; i < MaxX; i++)
            {
                for (int j = 0; j < MaxY; j++)
                {
                }
            }
        }

        #region InfoMethods
        public void ShowInfo()
        {
            foreach (var item in _floors)
            {
                foreach (var item1 in item.Rooms)
                {
                    Console.WriteLine($"X: {item1.Coord.Item1} - Y: {item1.Coord.Item2}\nCoins: {item1.Coins}\nDamage: {item1.Damage}");
                    Console.WriteLine("");
                }
            }
        }
        #endregion
    }
}
