using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Room
    {
        #region Fields
        private int _coins;
        private float _healt = 100;
        private bool _damage;
        private (int,int) _coord;
        #endregion
        #region Properties
        public (int, int) Coord
        {
            get {  return _coord; }
            set {  _coord = value; }
        }
        public int Coins
        {
            get { return _coins; }
            set
            {
                if (value <= 0)
                {
                    _coins = 0;
                    return;
                }
                _coins += value;
            }
        }
        public float Health
        {
            get { return _healt; }
        }
        public bool Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }
        #endregion

        #region Constructors
        public Room(int indexX, int indexY, int coin, bool damage)
        {

            Coord = (indexX, indexY);
            Coins = coin;
            Damage = damage;
        }
        public Room(int indexX, int indexY, int coin)
        {
            Coord = (indexX, indexY);
            Coins = coin;
            Damage = false;
        }
        public Room(int indexX, int indexY) : this(indexX, indexY, 0, false) { }
        #endregion

    }
}
