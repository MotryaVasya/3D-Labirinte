using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class SL_Manager : SL_Service<Player>
    {
        public string Path { get; } = "C:\\Users\\STUDENT\\source\\repos\\3D-Labirinte\\ConsoleApp2\\Informations";
        protected override Player CreateObjectFromData(string[] data)
        {
            Player player = new Player();

            // сделать сохранение Player
            return player;
        }

        protected override string[] GetDataFromObject(Player data)
        {
            string[] strings = new string[50];
            int index = 0;
            // сделать сохранение Player
            return strings;
        }


    }
}
