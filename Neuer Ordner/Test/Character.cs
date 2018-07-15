using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{    
	class Character
	{

        public string name;
        
        public int hitpoints;

        public int balance;
	

        public string Name
        {
            get { return name; }
        }

        public int Hitpoints
        {
            get { return hitpoints; }
        }

        public int Balance
        {
            get { return balance; }
        }
	}
}