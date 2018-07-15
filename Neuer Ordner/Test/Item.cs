using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{    
	class Item
	{

        public string name;
        private bool useable;
        private bool needsItem;
        private string description;
        private bool visible;
	
		public Item ( string _name, bool canUse, bool visible, string _description)
		{
            name = _name;
            useable = canUse;
            description = _description;
		}

        public string Name
        {
            get { return name; }
        }

        public bool Useable
        {
            get { return useable; }
        }

        public string Description
        {
            get { return description; }
        }

        public bool Visible
        {
            get { return visible; }
        }
	}
}