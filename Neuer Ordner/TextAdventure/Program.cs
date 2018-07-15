using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            Game _Game = new Game();
            _Game.initialize();
            
            while ( _Game.isRunning)
            {
                _Game.Update();
            }  
        }
    }
}
