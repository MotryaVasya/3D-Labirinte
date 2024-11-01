using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class BuildingManager : LinksRooms
    {
        private Building building;
        public Building Building
        {
            get { return building; }
            set { building = value; }
        }

        public override Dictionary<Room, List<Room>> LinksRoom { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        protected override Room CurrentRoom => throw new NotImplementedException();

        public void SetPosition(int x, int y, int z) // доделать
        {


        }
    }
}
