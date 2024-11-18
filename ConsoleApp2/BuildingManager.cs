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
        private List<Floor> _floors;
        private Random rnd;
        private (int, int, int) _maximum;
        private SL_Manager _SL_manager;
        private Dictionary<Room, Room> _NewlinksRoom;
        private Player _player;

        #endregion
        #region Properties
        public Dictionary<Room, Room> NewLinksRoom { get { return _NewlinksRoom; } set { _NewlinksRoom = value; } }
        public List<Floor> Floors { get => _floors; set => _floors = value; }
        public (int, int, int) Maximum { get => _maximum; set => _maximum = value; }
        public SL_Manager SL_Manager { get => _SL_manager; set => _SL_manager = value; }
        public Player Player { get => _player; set => _player = value; }
        #endregion
        #region Constructors
        public BuildingManager((int, int, int) maxX_and_maxY_and_maxFloors)
        {
            Floors = new List<Floor>();
            rnd = new Random();
            Maximum = maxX_and_maxY_and_maxFloors;
            SL_Manager = new SL_Manager();
            NewLinksRoom = new Dictionary<Room, Room>();
            Player = new Player();
        }
        #endregion
        public void CreateRooms()
        {
            Room room;
            for (int f = 1; f <= Maximum.Item3; f++)
            {
                var floor = new Floor(new List<Room>(), f);
                for (int i = 0; i < Maximum.Item1; i++)
                {
                    for (int j = 0; j < Maximum.Item2; j++)
                    {
                        room = new Room(i, j, rnd.Next(5), rnd.Next(5).Equals(2));
                        SecondsRooms.Add(room);
                        floor.AddRoom(room);
                    }
                }
                Floors.Add(floor);
                Console.WriteLine($"lvl: {f}");
                RandomizeLinks();
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
        private void SetValuesForPlayer()
        {
            var Input = Console.ReadKey(true).Key;
            switch (Input)
            {
                case ConsoleKey.UpArrow:
                    CheckMove(1);
                    break;
                case ConsoleKey.DownArrow:
                    CheckMove(-1);
                    break;
                case ConsoleKey.LeftArrow:
                    CheckMove(-2);
                    break;
                case ConsoleKey.RightArrow:
                    CheckMove(2);
                    break;

            }
        }
        private void CheckMove(int move)
        {
            int index = 0;
            foreach (KeyValuePair<Room, Room> item in NewLinksRoom)
            {
                while (index < 1)
                {
                    switch (move)
                    {
                        case 1: //вверх
                            SetValue(item);
                            break;
                        case -1://вниз
                            SetValue(item);
                            break;
                        case 2://вправо
                            SetValue(item);
                            break;
                        case -2://влево
                            SetValue(item);
                            break;
                    }
                    index++;
                }
            }
        }
        private void SetValue(KeyValuePair<Room, Room> room)// доделать 
        {
            if (Player.CurentCoord == (Maximum.Item1,Maximum.Item2))
            {
                
            }
            Player.CurentCoord = room.Value.Coord;
            if (room.Value.Damage == true) Player.Health -= 2;
            Player.Health = room.Value.Health;
            Player.Wallet += room.Value.Coins;
        }
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
                    case 2://вправо
                        SetLinks(2);
                        break;
                    case -2://влево
                        SetLinks(-2);
                        break;
                }
            }
            // это временно. для вывода информации
            SL_Manager.Save(Player /*добавить Player*/, SL_Manager.Path, true);
            NewLinksRoom = CopyDictionary(LinksRoom);
            LinksRoom.Clear();
            //ShowInfo(NewLinksRoom);
            SetValuesForPlayer();
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
                            LinksRoom.Add(CurentRoom, item);
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
                foreach (var value in LinksRoom.Values)
                {
                    if (key.Coord == CheckedKey.Coord && value.Coord == CheckedValue.Coord || key.Coord == CheckedValue.Coord && value.Coord == CheckedKey.Coord)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private Dictionary<Room, Room> CopyDictionary(Dictionary<Room, Room> Curent)
        {
            return Curent.ToDictionary(entry => entry.Key, entry => entry.Value); ;

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
            foreach (var item in Floors)
            {
                Console.WriteLine($"level: {item.Level}");//
            }
        }
        #endregion

    }
}