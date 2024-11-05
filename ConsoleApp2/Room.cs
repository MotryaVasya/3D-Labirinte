using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Room
    {
        #region FieldsAndProperties
        private PositionRoom _position;
        private int _coins;
        private float _healt;
        private float _damage;

        public PositionRoom Position
        {
            get { return _position; }
            set { _position = value; }
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
            set {  _healt = 100; }
        }
        public float Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }
        #endregion

        #region Constructors
        public Room(PositionRoom positionRoom, int coin)
        {
            Position = positionRoom;
            Coins = coin;
        }
        public Room(PositionRoom positionRoom) : this(positionRoom, 0)
        {
            
        }

        #endregion

    }
}
