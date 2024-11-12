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
        #region Constructors
        public BuildingManager((int, int, int) maxX_and_maxY_and_maxFloors)
        {
            Floors = new List<Floor>();
            Floor = new Floor(new List<Room>(), 0);
            rnd = new Random();
            Maximum = maxX_and_maxY_and_maxFloors;

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
            for (int i = 0; i < Maximum.Item1; i++)
            {
                for (int j = 0; j < Maximum.Item2; j++)
                {
                    room = new Room(i, j);
                    SecondsRooms.Add(room);
                    Floor.AddRoom(room);
                }

            }
            Method();
            Floors.Add(Floor);
        }
        /*
             1 = вверх
             -1 вниз
             2 = в право
             -2 = в лево
             0 = вверх по этажу
             3 = вниз по этажу
        */
        private void Method() // назвать по другому
        {

            while (LinksRoom.Count != 5)
            {
                int move = rnd.Next(-2, 3);
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
                    case 0://вверх по этажу
                        SetLinks(0);
                        break;
                    case 3://вниз по этажу
                        SetLinks(3);
                        break;
                }

            }
            // это временно. для вывода информации
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("");
            }
            ShowInfo(LinksRoom);
            return;
        }
        private void SetLinks(int move)
        {
            if (CurrentRoom.Coord.Item2 < Maximum.Item2 && CurrentRoom.Coord.Item2 >= 0)   // вверх и вниз
            {
                if (move == 1)
                {
                    if (CheckContainceByCoords(SecondsRooms, CurrentRoom, move))
                    {
                        foreach (var item in SecondsRooms)
                        {
                            if (item.Coord.Item2 == CurrentRoom.Coord.Item2 + 1 && CheckLinks(CurrentRoom, item))
                            {
                                LinksRoom.Add(CurrentRoom, new List<Room>() { item });
                                CurrentRoom = item;
                                return;
                            }
                        }
                    }
                }
                if (move == -1)
                {
                    if (CheckContainceByCoords(SecondsRooms, CurrentRoom, move))
                    {
                        foreach (var item in SecondsRooms)
                        {

                            if (item.Coord.Item2 == CurrentRoom.Coord.Item2 - 1 && CheckLinks(CurrentRoom, item))
                            {
                                LinksRoom.Add(CurrentRoom, new List<Room>() { item });
                                CurrentRoom = item;
                                return;
                            }
                        }
                    }
                }
            }

            if (CurrentRoom.Coord.Item1 < Maximum.Item1 && CurrentRoom.Coord.Item1 >= 0)   // в лево и в право
            {
                if (move == 2)
                {
                    if (CheckContainceByCoords(SecondsRooms, CurrentRoom, move))  
                    {
                        foreach (var item in SecondsRooms)
                        {
                            if (item.Coord.Item1 == CurrentRoom.Coord.Item1 + 1 && CheckLinks(CurrentRoom, item))
                            {
                                LinksRoom.Add(CurrentRoom, new List<Room>() { item });
                                CurrentRoom = item;
                                return;
                            }
                        }
                    }
                }
                if (move == -2)
                {
                    if (CheckContainceByCoords(SecondsRooms, CurrentRoom, move))
                    {
                        foreach (var item in SecondsRooms)
                        {
                            if (item.Coord.Item1 == CurrentRoom.Coord.Item1 - 1 && CheckLinks(CurrentRoom, item))
                            {
                                LinksRoom.Add(CurrentRoom, new List<Room>() { item });
                                CurrentRoom = item;
                                return;
                            }
                        }
                    }
                }
            }
            /* if (move == 0)
             {
                 foreach (var item in _floors)
                 {
                     foreach (var item1 in item.Rooms)
                     {

                     }
                 }


                 foreach (var item in SecondsRooms)
                 {
                     if (CheckLinks(CurrentRoom, item) == false)
                     {
                         LinksRoom.Add(CurrentRoom, new List<Room>() { item });
                         CurrentRoom = item;
                         return;
                     }
                     break;
                 }
             }*/
            /*if (move == 3)
            {
                foreach (var item in _floors)
                {
                    foreach (var item1 in item.Rooms)
                    {

                    }
                }


                foreach (var item in SecondsRooms)
                {
                    if (CheckLinks(CurrentRoom, item) == false)
                    {
                        LinksRoom.Add(CurrentRoom, new List<Room>() { item });
                        CurrentRoom = item;
                        return;
                    }
                    break;
                }
            }*/
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
                    case 0:
                        break;
                    case 3:
                        break;
                }
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
                    {//     0,0     1,0           1,0       0,0           0,0          0,0
                        Console.WriteLine(key);
                        Console.WriteLine(CheckedValue);
                        if (key == CheckedKey && value == CheckedValue || key == CheckedValue && value == CheckedKey)
                        {
                            Console.WriteLine("такая связь уже есть");
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
        #endregion

    }
}