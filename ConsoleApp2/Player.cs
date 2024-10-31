using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Player
    {
        private float _health;
        private float _wallet;

        public float Health
        {
            get
            {
                return IsDie() ? 0 : _health;
            }
            set
            {
                if (IsDie()) Console.WriteLine("Вы умерли");
                _health += value;
                if (_health >= 100) _health = 100; return;
            }
        }
        public float Wallet
        {
            get 
            { 
                return _wallet <= 0?0:_wallet; 
            }
            set 
            { 
                if (_wallet <= 0) _wallet = 0;
                _wallet = value; 
            }
        }
        private bool IsDie()
        {
            return _health <= 0 ? true : false;
        }
    }
}
