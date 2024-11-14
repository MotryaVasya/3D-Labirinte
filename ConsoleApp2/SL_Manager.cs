using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class SL_Manager : SL_Service<Dictionary<Room, List<Room>>>
    {
        public string Path { get; } = "C:\\Users\\STUDENT\\source\\repos\\3D-Labirinte\\ConsoleApp2\\Informations";
        protected override Dictionary<Room, List<Room>> CreateObjectFromData(string[] data)
        {
            Dictionary<Room, List<Room>> keyValuePairs = new Dictionary<Room, List<Room>>();
            List<Room> list = new List<Room>();

            foreach (string item in data)
            {
                foreach (var simbol in item)
                {
                    //Room newRoom = new Room();
                    //list.Add(new Room());

                }
            }
            return keyValuePairs;
        }

        protected override string[] GetDataFromObject(Dictionary<Room, List<Room>> data)
        {
            string[] strings = new string[data.Count * 10];
            int index = 0;
            foreach (var key in data.Keys)
            {
                strings[index] += (key.Coord.Item1, SptChar, key.Coord.Item2, SptChar, key.Health, SptChar, key.Coins, "\n").ToString();
                index++;
                foreach (var values in data.Values)
                {
                    foreach (var value in values)
                    {
                        strings[index] += (value.Coord.Item1, SptChar, value.Coord.Item2, SptChar, value.Health, SptChar, value.Coins, "\n").ToString();
                        index++;
                    }
                }

                strings[index++] += "-";
            }
            return strings;
        }
    }
}
