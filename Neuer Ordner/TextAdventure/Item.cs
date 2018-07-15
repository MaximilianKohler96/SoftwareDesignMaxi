using System;
using System.Linq;
using System.Collections.Generic;

namespace TextAdventure
{
    class Item : Gameobject
    {
        public bool Carryable;
        public int Attackdamage;
        
        public int Value = 1;
        public Room isUsableHere;
        public string gotused;
        public bool isUsable;
        public static void useitem(Character c, Item i, int l)
        {
            Console.WriteLine(i.gotused);
            if (i.Name.ToLower() == "dollar")
            {
                c.Location.CharacterList[l].Characterinventory.Add(i);
                c.Characterinventory.Remove(i);
                c.Characterinventory.Add(c.Location.CharacterList[l].Characterinventory[0]);

                
            }
            if (i.Name.ToLower() == "knife")
            {
                Item Herbs = new Item();
                Herbs.Name ="Herbs";
                Herbs.Describtion="That's exactly what you have been looking for.";
                c.Location.RoomInventory.Add(Herbs);
               
            }
            if (i.Name.ToLower() == "potion")
            {
                c.HealthPoints += 25;
                Console.WriteLine("Your Health Points are " + c.HealthPoints + " now.");
                c.Characterinventory.Remove(i);
            }
        }
    }
    
}