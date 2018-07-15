using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TextAdventure
{
    public class Gameobject    
    {
        public string Name;
        public string Describtion;
        public static string getname (Gameobject name)
        {
            return name.Name;
        }
        public static string getdescribtion(Gameobject describtion)
        {
            return describtion.Describtion;
        }
    } 
    class Game 
    {
        
        public string Startuptext = "Hello Stranger. Welcome to my Textadventure.\n\n" + 
        "Since 3 days you are out of Herbs and " + 
        "at least you didn't smoke for this timespan as well. \n" +
        "You nearly would do everything to reach the next hit. \nSo it seems like your mission is to make the stuff clear.\n"+
        "Take the money you stole from your mom to satisfy your addiction. "+
        "Press enter to continue..."; 
        public string Endtext = "You reached the end of the this Textadventure.\n" +
        "No matter how you managed your mission. U did it. Congratulations.";
        public bool isRunning = true;
        private bool _gameOver = false;
        public List<Room> Roomlist = new List<Room>();
        
        Room Wayhome = new Room
        {
            Name="Way back home",
            Available = false,
        };
        Room Street = new Room
        {
            Name="Street",
            Describtion= "I'ts dark outside here. The Lanterns flicker and you hear a police siren a few blocks away. In front of you there is a dilapidatet, old House.",
            Available=true,
        };   
        Room Kitchen = new Room
        {
            Name="Kitchen",
            Describtion="The Kitchen is pretty messy.",
            Available=true,
            CharacterList = new List<Character>(),
        };
        Room Courtyard = new Room
        {
            Name="Courtyard",
            Describtion="Better don't stay longer as necessary.",
            Available=true,
        };
        Room Floor = new Room
        {
            Name="Floor",
            Describtion="You actually can smell the taste of the herbs.",
            Available=true,
        };
        Room Growroom = new Room
        {
            Name="Growroom",
            Describtion="Here are so much plants! Nobody would notice, if you grab some.",
            Available=false,
        };
        Room Dealerroom = new Room
        {
            Name = "Dealerroom",
            Describtion = "Your Mom would hussle this so hard. But who cares?",
            Available=true,
        };

        Item Dollar = new Item
        {
            Name = "Dollar",
            Describtion = "You can buy so much great stuff with Money.",
            Value=0,
            gotused = "You used your Money to buy the herbs."
            
        };
        Item Plants = new Item 
        {
            Name = "Plants",
            Describtion = "Take a knife to harvest the Herbs of the Plant.",
            Carryable=false,
        };
        Item Baseballbat= new Item 
        {
            Name = "Baseball bat",
            Describtion = "You'll do fine with this wonderful piece of wood.",
            Carryable=true,
            Attackdamage = 20,
        };
        Item Knife = new Item
        {
            Name = "Knife", 
            Describtion = "This knife is very sharp, be carefull with it.",
            Attackdamage = 40,
            Carryable = true,
            gotused = "You used the knife to harvest the Herbs."
            
        };
        Item Pistol = new Item
        {
            Name = "Pistol",
            Describtion = "There's nothing to say about. Just be carefull.",
            Attackdamage = 80,
            Carryable = true,
        };
        Item Herbs = new Item
        {
            Name ="Herbs",
            Describtion="That's exactly what you have been looking for.",
            Carryable =false,
        };
        Item Potion = new Item
        {
            Name="Potion",
            Describtion="This Potion restores 25 Health Points.",
            Value = 1,
            Carryable = false,
            gotused = "You used the Potion to restore 25 Health Points.",
            isUsable = true,
            
        };

        Character Player = new Character
        {
            Isalive = true,
            HealthPoints = 100,
            AttackDamage = 10,
           // Characterinventory = new List<Item>(),
        
        };
        Character Lady = new Character
        {
            Name = "Pretty Lady",
            Describtion = "Wouldn't it be pleasure to take this wonderfull Lady with you?",
            Dialouge = {"Hello honey. How are you?", "I like your clothing style.", "If there wouldn't be my boyfriend, I would come with you my sweetie." },
            HealthPoints = 50,
            AttackDamage = 10,

        };
        Character Ladysboyfriend = new Character
        {
            Name = "Lady's Boyfriend",
            Describtion = "Better be awared of him, if you are interested in the Pretty Lady.",
            HealthPoints = 100,
            AttackDamage = 10,
            Characterinventory = new List<Item>(),
            Dialouge = {"I say it only once: don't touch my girlfriend."},
        };
        Character Dealer = new Character
        {
            Name="Dealer",
            Describtion="It say's don't take the drugs you are dealing with, doesn't it?",
            Dialouge = {"Hey you, what's up man..", "Give me your money, if you want to buy some herbs"},
            HealthPoints = 100,
            AttackDamage = 10,

        };
        Character Man = new Character
        {
            Name="Unknown Man",
            Describtion="It seems like the muscled man blocks the way to the Growroom.",
            HealthPoints= 200,
            AttackDamage = 20,
            Isalive = true,
            Dialouge = {"As long as I am here, you won't be allowed to enter the Growroom."}

        };
        Character Penn = new Character
        {
            Name="Penn",
            Describtion="The Penn smells bad.",
            HealthPoints= 30,
            AttackDamage = 10,
            IsAgressive = false,
            Dialouge = {"Hey Man, do you got some herbs for me?", "It's so cold outside here...brrrr."},

        };
        public void initialize()
        {
            Roomlist.Add(Kitchen);  
            Roomlist.Add(Street);
            Roomlist.Add(Floor);
            Roomlist.Add(Courtyard);
            Roomlist.Add(Dealerroom);
            Roomlist.Add(Growroom);
            Roomlist.Add(Wayhome);

            Room.addExitNorth(Street, Floor);
            Room.addExitWest(Street, Courtyard);
            Room.addExitEast(Floor, Kitchen);
            Room.addExitWest(Floor, Growroom);
            Room.addExitNorth(Floor, Dealerroom);
            Room.addExitEast(Street, Wayhome);
            
            Kitchen.RoomInventory.Add(Knife);
            Kitchen.RoomInventory.Add(Potion);
            //Growroom.RoomInventory.Add(Herbs);
            Growroom.RoomInventory.Add(Plants);
            Courtyard.RoomInventory.Add(Baseballbat);
            
            Kitchen.CharacterList.Add(Ladysboyfriend);
            Floor.CharacterList.Add(Man);
            Floor.CharacterList.Add(Lady);
            Dealerroom.CharacterList.Add(Dealer); 
            Courtyard.CharacterList.Add(Penn);

            Ladysboyfriend.Characterinventory.Add(Pistol);
            Dealer.Characterinventory.Add(Herbs);
            //Character.giveweapon(Ladysboyfriend, Pistol);
            Knife.isUsableHere = Growroom;
            Dollar.isUsableHere = Dealerroom;
            
            Player.Location = Street;
            //Player.Pocket = Dollar;
            //Penn.Pocket = Dollar;
            
            Player.Characterinventory.Add(Dollar);
            Penn.Characterinventory.Add(Dollar);
            Character.getmoney(Player, Dollar, 50);
            Character.getmoney(Penn, Dollar, 5);
            
            Console.WriteLine(Startuptext);
            Console.Read();
            Console.Write("...50 Dollar have been added to your inventory.\n\n");
            
            Console.WriteLine("You just spawned in the " + Player.Location.Name + ". Find a way to get your Herbs followed by the walk to your home again.");
            
            Console.WriteLine("\nType any command or 'h' / 'help' to get the command list");
            
            
        }

        public Game()
        {
            
            
        }
        
        public void doAction(string input)
        {   
            Console.WriteLine();

            if (Lady.Dialougeline > 1)
            {
                Random rnd = new Random();
                Ladysboyfriend.IsAgressive = true; 
                //Ladysboyfriend.Location.CharacterList.Remove(Ladysboyfriend);
                //Roomlist[rnd.Next(Roomlist.Count)].CharacterList.Add(Ladysboyfriend);
            } 
            if (Penn.Dialougeline > 0)
            {
                Penn.IsAgressive = true;
            }
            if (Man.Isalive == false)
            {
                Growroom.Available = true;
            }
            foreach (var item in Player.Characterinventory)
            {
                if (item.Name == "Herbs")
                {
                    Wayhome.Available = true;
                }
            }
            foreach (var character in Player.Location.CharacterList)
                {
                    if (character.IsAgressive == true)
                    {
                        Character.getattack(Player, character);
                    }
                }
            
            try
            {
                string pattern = @"([a-zA-Z]+) ";
                Match firststring  = Regex.Match(input, pattern);
                
                if (input == "n" || input == "north")
                {
                    if (Player.Location.Northexit != null && (Player.Location.Northexit.Available == true))
                    {
                        Player.Location = Player.Location.Northexit;
                        Character.getCharacterLocation(Player);
                        Room.getCharacterlist(Player.Location);
                        Room.getRoominventory(Player.Location);
                    } 
                    else 
                    {
                        Console.WriteLine("There is no way! Choose another one!");
                    }
                }
                if (input == "e" || input == "east")
                {
                    if (Player.Location.Eastexit != null  && (Player.Location.Eastexit.Available == true))
                    {
                        Player.Location = Player.Location.Eastexit;
                        Character.getCharacterLocation(Player);
                        Room.getCharacterlist(Player.Location);
                        Room.getRoominventory(Player.Location);
                    } 
                    else 
                    {
                        Console.WriteLine("There is no way! Choose another one!");
                    }
                }
                if (input == "s" || input == "south")
                {
                    if (Player.Location.Southexit != null && (Player.Location.Southexit.Available = true))
                    {
                        Player.Location = Player.Location.Southexit;
                        Character.getCharacterLocation(Player);
                        Room.getCharacterlist(Player.Location);
                        Room.getRoominventory(Player.Location);
                    } 
                    else 
                    {
                        Console.WriteLine("There is no way! Choose another one!");
                    }
                }
                if (input == "w" || input == "west")
                {
                    if (Player.Location.Westexit != null  && (Player.Location.Westexit.Available == true))
                    {
                        Player.Location = Player.Location.Westexit;
                        Character.getCharacterLocation(Player);

                        Room.getCharacterlist(Player.Location);
                        Room.getRoominventory(Player.Location);
                    } 
                    else
                    {
                        Console.WriteLine("There is no way! Choose another one!");
                    }
                } 

                if (input == "help" || input == "h")
                {
                    Console.WriteLine("'l' or 'look' ---------> Shows you the room and its exits");
                    Console.WriteLine("'t' or 'take' <item>: -> Attempts to pick up an item.");
                    Console.WriteLine("'d' or 'drop': --------> Attempts to drop an item.");
                    Console.WriteLine("'u' or 'use' <item>: --> Attempts to use an item.");
                    Console.WriteLine("'i' or 'inventory': ---> Allows you to see the items in your inventory.");
                    Console.WriteLine("'q' or 'quit': --------> Quits the game.");
                    Console.WriteLine("'a' or 'attack' <char>:  Attempts to attack a character");
                    Console.WriteLine("'lookat' <x>: ---------> Gives you information about a specific item in your inventory or your current room,\n " +
                    "                        either more information about a character in your current room. ( <x> = <char> or <item> )");
                    Console.WriteLine("'talkto' <character> --> Attempts you to talk to characters.");
                    Console.WriteLine();
                    Console.WriteLine("Directions can be input as either the full word, or the abbriviation, e.g. 'north' or 'n'");
                    return;
                }

                if (input == "i" || input == "inventory")
                {
                    if (Player.Characterinventory.Count() > 0)
                    {
                        Console.WriteLine("Your inventory contains the following Items: ");
                        Character.getCharacterinventory(Player);
                        Console.WriteLine();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Your inventory contains no Items.");
                    }
                }
                //if (input.StartsWith("a "))
                if (input.StartsWith("t ") || input.StartsWith("take "))
                {   
                    string chooseditem = input.Substring(firststring.Value.Length, input.Length - firststring.Value.Length);
                    Character.take(Player.Location, Player, chooseditem);
                }
                if (input.StartsWith("d ") || input.StartsWith( "drop "))
                {
                    
                    

                    string chooseditem = input.Substring(firststring.Value.Length, input.Length - firststring.Value.Length);
                    Character.drop(Player.Location, Player, chooseditem);
                }
                if (input == "t" || input == "take")
                {
                    Console.Write("Choose the Item you want to pick up: 't' or 'take' <item>");
                }
                
                if (input == "l" || input == "look")
                {
                    Console.Write(Player.Location.Name + ": ");
                    Console.WriteLine(Player.Location.Describtion);
                    Room.getExitDescribtion(Player);
                    Console.WriteLine("You see");
                    Room.getCharacterlist(Player.Location);
                    Room.getRoominventory(Player.Location);
                }
                if (input.StartsWith( "use ") || input.StartsWith("u "))
                {
                    string chooseditem = input.Substring(firststring.Value.Length, input.Length - firststring.Value.Length);;
                    Character.use(Player, chooseditem);
                }
                if (input.StartsWith("a ") || input.StartsWith("attack "))
                {  
                    string choosedcharacter = input.Substring(firststring.Value.Length, input.Length - firststring.Value.Length);
                    Character.attack(Player, choosedcharacter);
                }
                if (input.StartsWith("lookat "))
                {
                    string choice = input.Substring(firststring.Value.Length, input.Length - firststring.Value.Length);
                    Character.lookat( Player, choice);
                }
                if (input.StartsWith("talkto "))
                {
                    string choosedcharacter = input.Substring(firststring.Value.Length, input.Length - firststring.Value.Length);
                    Character.talkto(Player, choosedcharacter);
                }
                
                
            }
            

            //if (Player.Location)
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid command. Type 'h' or 'help to get the command list.");
                
            }
            
        }
        
        public void Update()
        {
            if (Player.Isalive == false)
            {
                Console.WriteLine("You died. Game Over!");
                isRunning = false;
            }
            if (Player.Location == Wayhome)
            {
                Console.WriteLine(Endtext);
                isRunning = false;
            }
            Console.Write("\n  -> Command: ");
            string input = Console.ReadLine().ToLower();

            if (input == "quit" || input == "q")
            {
                isRunning = false;
                return;
            }
            
            if (!_gameOver)
            {
                doAction(input);
                
            }
            else
            {
                Console.WriteLine("\nNope. Time to quit. \n");
            }
        }
    }
}