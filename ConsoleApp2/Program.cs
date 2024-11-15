using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BuildingManager buildingManager = new BuildingManager((3, 3, 4));
            buildingManager.CreateRooms();
            //buildingManager.ShowInfo();
            Console.WriteLine("");
            Console.ReadLine();
        }
    }
}
