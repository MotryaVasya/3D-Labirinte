using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class BuildingManager : LinksRooms
    {
        #region Fields
        private Floor _floor;
        private List<Floor> _floors;
        private Random rnd;
        private (int, int, int) _maximum;

        #endregion
        private SL_Manager SL_manager;
        #region Constructors
        public BuildingManager((int, int, int) maxX_and_maxY_and_maxFloors)
        {
            Floors = new List<Floor>();
            Floor = new Floor(new List<Room>(), 0);
            rnd = new Random();
            Maximum = maxX_and_maxY_and_maxFloors;
            SL_manager = new SL_Manager();

        }

        #endregion
        #region Properties
        public Floor Floor { get => _floor; set => _floor = value; }
        public List<Floor> Floors { get => _floors; set => _floors = value; }
        public (int, int, int) Maximum { get => _maximum; set => _maximum = value; }

        #endregion
        public void CreateRooms()
        {
            Room room;
            for (int f = 1; f <= Maximum.Item3; f++)
            {
                for (int i = 0; i < Maximum.Item1; i++)
                {
                    for (int j = 0; j < Maximum.Item2; j++)
                    {
                        room = new Room(i, j);
                        SecondsRooms.Add(room);
                        Floor.AddRoom(room);
                    }
                }
                Floor.Level++;
                Floors.Add(Floor);
                RandomizeLinks();
                Floor.CleareRooms();
            }
        }
        /*
             1 = вверх
             -1 вниз
             2 = в право
             -2 = в лево
             0 = вверх по этажу
             3 = вниз по этажу
        */
        private void RandomizeLinks() // назвать по другому
        {

            while (LinksRoom.Count != 3)
            {
                int move = rnd.Next(-2, 3);
                while (move == 0)
                {
                    move = rnd.Next(-2, 3);
                }
                switch (move)
                {
                    case 1: //вверх
                        SetLinks(1);
                        break;
                    case -1://вниз
                        SetLinks(-1);
                        break;
                    case 2://в право
                        SetLinks(2);
                        break;
                    case -2://в лево
                        SetLinks(-2);
                        break;
                }

            }

            // это временно. для вывода информации
            WriteEmptyAndFloorLvl();
            ShowInfo(LinksRoom);
            SL_manager.Save(LinksRoom,SL_manager.Path, false);
            LinksRoom.Clear();
        }
        private void SetLinks(int move)
        {
            if (CurentRoom.Coord.Item2 < Maximum.Item2 && CurentRoom.Coord.Item2 >= 0 ||
                CurentRoom.Coord.Item1 < Maximum.Item1 && CurentRoom.Coord.Item1 >= 0)   // вверх и вниз
            {

                if (CheckContainceByCoords(SecondsRooms, CurentRoom, move))
                {
                    foreach (var item in SecondsRooms)
                    {
                        if (CheckEgaleCoords(item.Coord, CurentRoom.Coord, move) && CheckLinks(CurentRoom, item))
                        {
                            LinksRoom.Add(CurentRoom, new List<Room>() { item });
                            CurentRoom = item;
                            return;
                        }
                    }
                }
            }
        }

        private bool CheckContainceByCoords(List<Room> secondsRooms, Room currentRoom, int move)
        {
            foreach (var item in secondsRooms)
            {
                switch (move)
                {
                    case 1:
                        if (item.Coord.Item1 == currentRoom.Coord.Item1 && item.Coord.Item2 == currentRoom.Coord.Item2 + 1) return true;
                        break;
                    case -1:
                        if (item.Coord.Item1 == currentRoom.Coord.Item1 && item.Coord.Item2 == currentRoom.Coord.Item2 - 1) return true;
                        break;
                    case 2:
                        if (item.Coord.Item1 == currentRoom.Coord.Item1 + 1 && item.Coord.Item2 == currentRoom.Coord.Item2) return true;
                        break;
                    case -2:
                        if (item.Coord.Item1 == currentRoom.Coord.Item1 - 1 && item.Coord.Item2 == currentRoom.Coord.Item2) return true;
                        break;
                }
            }

            return false;
        }
        private bool CheckEgaleCoords((int, int) SecondRoomCoord, (int, int) CurentRoomCoord, int m)
        {
            switch (m)
            {
                case 1:
                    if (SecondRoomCoord.Item2 == CurentRoomCoord.Item2 + 1 && SecondRoomCoord.Item1 == CurentRoomCoord.Item1) return true;
                    break;
                case -1:
                    if (SecondRoomCoord.Item2 == CurentRoomCoord.Item2 - 1 && SecondRoomCoord.Item1 == CurentRoomCoord.Item1) return true;
                    break;
                case 2:
                    if (SecondRoomCoord.Item2 == CurentRoomCoord.Item2 && SecondRoomCoord.Item1 == CurentRoomCoord.Item1 + 1) return true;
                    break;
                case -2:
                    if (SecondRoomCoord.Item2 == CurentRoomCoord.Item2 && SecondRoomCoord.Item1 == CurentRoomCoord.Item1 - 1) return true;
                    break;
            }
            return false;
        }
        private bool CheckLinks(Room CheckedKey, Room CheckedValue) // сделать тоже самое только по кординатам потому что создает новый объект класса и занимает другую память
        {
            foreach (var key in LinksRoom.Keys)
            {
                foreach (var values in LinksRoom.Values)
                {
                    foreach (var value in values)
                    {
                        if (key.Coord == CheckedKey.Coord && value.Coord == CheckedValue.Coord || key.Coord == CheckedValue.Coord && value.Coord == CheckedKey.Coord)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        #region InfoMethods
        public void ShowInfo()
        {
            foreach (var item in Floors)
            {
                foreach (var item1 in item.Rooms)
                {
                    Console.WriteLine($"X: {item1.Coord.Item1} - Y: {item1.Coord.Item2}\nCoins: {item1.Coins}\nDamage: {item1.Damage}");
                    Console.WriteLine("");
                }
            }
        }
        public void WriteEmptyAndFloorLvl()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("");
            }
            Console.WriteLine($"level: {Floor.Level}");
        }
        #endregion

    }
}