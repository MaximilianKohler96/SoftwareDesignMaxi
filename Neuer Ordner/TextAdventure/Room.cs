using System;
using System.Linq;
using System.Collections.Generic;

namespace TextAdventure
{
    // Liste oder Array für inventory etc.
    // Durchspielen der möglichen Kämpfe und anpassen der Lebenspunkte 
    class Room : Gameobject
    {
        public Room Northexit;
        public Room Eastexit;
        public Room Southexit;
        public Room Westexit;
        public bool Available;
        
        //public List<Character> CharacterInventory = new List<Character>();
        public List<Item> RoomInventory = new List<Item>();
        public List<Character> CharacterList = new List<Character>();
        public static void addExitNorth (Room r, Room north)
        {
            r.Northexit = north;
            north.Southexit = r;
        }
        public static void addExitEast (Room r, Room east)
        {
            r.Eastexit = east;
            east.Westexit = r;
        }
        public static void addExitSouth (Room r, Room south)
        {
            r.Southexit = south;
            south.Northexit = r;
        }
        public static void addExitWest (Room r, Room west)
        {
            r.Westexit = west;
            west.Eastexit = r;
        }
        public static void getCharacterlist(Room r)
        {
            
            
            foreach (var character in r.CharacterList)
            {
                
                if (character.IsAgressive == true)
                {
                    Console.WriteLine(character.Name + ". Watch out! " + character.Name + " is agressive. You will get attacked.");
                }
                else 
                {
                    Console.WriteLine(character.Name);
                }
            }
            
        }
        public static void getRoominventory(Room r)
        {
            
            
            foreach (Item item in r.RoomInventory)
            
            {
                Console.WriteLine(item.Value + " " + item.Name);
            }
            
            
        }

        public static void getExitDescribtion (Character c)
        {
            
            if (c.Location.Northexit != null)
            {
                Console.WriteLine("To the north there is the " + c.Location.Northexit.Name + ".");
            }
            if (c.Location.Eastexit != null)
            {
                Console.WriteLine("To the east there is the " + c.Location.Eastexit.Name + ".");
            }
            if (c.Location.Southexit != null)
            {
                Console.WriteLine("To the shouth there is the " + c.Location.Southexit.Name + ".");
            }
            if (c.Location.Westexit != null)
            {
                Console.WriteLine("To the west there is the " + c.Location.Westexit.Name + ".");
            }
        }
        
        public static void addItemtoRoom (Item i,Room r)
        {
            r.RoomInventory.Add(i);
        }
        

    }
}