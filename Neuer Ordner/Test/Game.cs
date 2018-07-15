using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
	class Game
	{
		Location currentLocation;

		public bool isRunning = true;
        private bool _gameOver = false;

		private List<Item> inventory;

		public Game()
		{
			inventory = new List<Item>();

			Console.WriteLine("Welcome Adventurer. This is a Text based RPG mady in Furtwangen. Enjoy!");
            Console.WriteLine("Type 'h' or 'help' and press Enter for help.");

			// build the "map"
			Location l1 = new Location("Haven", "You are standing at the pier in the haven of the small island Ubuntu. \nTo your right is the small ship you came with from the mainland.\nTo your left you can see the old Captain that brought you here, smoking pipe.");
			Item key = new Item("key", true, false, "A big old key made from Brass. The Time really eroded this relic");
			l1.addItem(key);

			Location l2 = new Location("Marketplace", "You are standing in the middle of a busy marketplace. \nYou can smell food and you hear the weaponsmith hitting glowing steel.");
			Item sword = new Item("sword", true, true, "A short sword. It looks pretty dull.");
            Item armor = new Item("armor", true, true, "An old chain mail that doesnt look like it could take a hit from a sword, but better than nothing");
			l2.addItem(sword);
            l2.addItem(armor);

            Location l3 = new Location("Herb Garden", "You enter a herb garden that smells like the herb fields in the provence. \nBut something is wrong with this place, there is nobody here...");
			Item pot = new Item("pot", true, true, "A pot filled with a red fluid that glows. It looks magical.");
            Item garlic = new Item("garlic", true, true, "A clove of garlic, whatever that's good for...");
			l3.addItem(pot);
            l3.addItem(garlic);

            Location l4 = new Location("Orchard", "You enter a small orchard. \nThere is a farmer harvesting apples. \nHe didn't recognize you yet and there is a beautiful red Apple in a basket behind the Farmer.");
			Item apple = new Item("apple", true, true, "An ordinary red apple that looks delicious.");
			l4.addItem(apple);

            Location l5 = new Location("Graveyard", "You enter a creepy graveyard, the sun vanished behind the fog.");

            Location l6 = new Location("Crypt", "You are entering a dark crypt. After your eyes adjusted to the darkness you can see a big grave in the middle of the room. \nThe Frontplate of the grave says ''ARTEMIS'', the rest is eroded. \nThere is a chest in front of the grave.");
			

			
			l1.addExit(new Exit(Exit.Directions.West, l2));
			
            l2.addExit(new Exit(Exit.Directions.East, l1));
            l2.addExit(new Exit(Exit.Directions.North, l3));
            l2.addExit(new Exit(Exit.Directions.South, l4));
            l2.addExit(new Exit(Exit.Directions.West, l5));

            l3.addExit(new Exit(Exit.Directions.South, l2));

            l4.addExit(new Exit(Exit.Directions.North, l2));

            l5.addExit(new Exit(Exit.Directions.East, l2));
            l5.addExit(new Exit(Exit.Directions.West, l6));

            l6.addExit(new Exit(Exit.Directions.East, l5));

			currentLocation = l1;
			showLocation();
		}

		public void showLocation()
		{
			Console.WriteLine("\n" + currentLocation.getTitle() + "\n");
			Console.WriteLine(currentLocation.getDescription());

			if (currentLocation.getInventory().Count > 0)
			{
				Console.WriteLine("\nYou can see the Following items:\n");

				for ( int i = 0; i < currentLocation.getInventory().Count; i++ )
				{
					Console.WriteLine(currentLocation.getInventory()[i].Name);
				}
			}
	
			Console.WriteLine("\nAvailable Exits: \n");

			foreach (Exit exit in currentLocation.getExits() )
			{
				Console.WriteLine(exit.getDirection());
			}

			Console.WriteLine();
		}

        // TODO: Implement the input handling algorithm.
		public void doAction(string command)
		{
           //Help command is NEW
            if (command == "help" || command == "h")
           {
                Console.WriteLine("Welcome to my Text adventure, here is some advice!");
                Console.WriteLine("'l' / 'look':        Shows you the room, its exits, and any items it contains.");
                Console.WriteLine("'Look at X':         Gives you information about a specific item in your \n                     inventory, where X is the items name.");
                Console.WriteLine("'pick up X':         Attempts to pick up an item, where X is the items name.");
                Console.WriteLine("'use X':             Attempts to use an item, where X is the items name.");
                Console.WriteLine("'i' / 'inventory':   Allows you to see the items in your inventory.");
                Console.WriteLine("'q' / 'quit':        Quits the game.");
                Console.WriteLine();
                Console.WriteLine("Directions can be input as either the full word, or the abbriviation, \ne.g. 'North or N'");
                return;
           }
            
            //If statement to access the player inventory
            //This can't be changed a great deal
            if (command == "inventory" || command == "i")
            {
                showInventory();
                Console.WriteLine();
                return;
            }

            //If statement for player to pick up objects
            //This works fine. Change how the function works later though.
            if (command.Length >= 7 && command.Substring(0, 7) == "pick up")
            {
                if (command == "pick up")
                {
                    Console.WriteLine("\nPlease specify what you would like to pick up.\n");
                    return;
                }
                if (currentLocation.getInventory().Exists(x => x.Name == command.Substring(8)) && currentLocation.getInventory().Exists(x => x.Useable == true))
                {
                    inventory.Add(currentLocation.takeItem(command.Substring(8)));
                    Console.WriteLine("\nYou pick up the " + command.Substring(8) + ".\n");
                    return;
                }
                if (currentLocation.getInventory().Exists(x => x.Name == command.Substring(8)) && currentLocation.getInventory().Exists(x => x.Useable == false))
                {
                    Console.WriteLine("\nYou cannot pick up the " + command.Substring(8) + ".\n");
                    return;
                }
                else
                {
                    Console.WriteLine("\n" + command.Substring(8) + " does not exist.\n");
                    return;
                }
            }
           
            if (command == "look" || command == "l")
            {
                showLocation();
                if (currentLocation.getInventory().Count == 0)
                {
                    Console.WriteLine("There are no items of interest in the room.\n");
                }
                return;
            }
            
            if (command.Length >= 7 && command.Substring(0, 7) == "look at")
            {
                if (command == "look at")
                {
                    Console.WriteLine("\nPlease specify what you wish to look at.\n");
                    return;
                }
                if (currentLocation.getInventory().Exists(x => x.Name == command.Substring(8)) || inventory.Exists(x => x.Name == command.ToLower().Substring(8)))
                {
                    if (command.Substring(8).ToLower() == "sword")
                    {
                        Console.WriteLine("\n" + currentLocation.getInventory().Find(x => x.Name.Contains("sword")).Description + "\n");
                        return;
                    }

                    if (command.Substring(8).ToLower() == "window")
                    {
                        Console.WriteLine("\n" + currentLocation.getInventory().Find(x => x.Name.Contains("window")).Description + "\n");
                        return;
                    }

                    if (command.Substring(8).ToLower() == "smashed window")
                    {
                        Console.WriteLine("\n" + currentLocation.getInventory().Find(x => x.Name.Contains("smashed window")).Description + "\n");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("\nThat item does not exist in this location or your inventory.\n");
                    return;
                }
            }

            if (command.Length >= 3 && command.Substring(0, 3) == "use")
            {
                if (command == "use")
                {
                    Console.WriteLine("\nPlease specify what you wish to use.\n");
                    return;
                }
                if (inventory.Exists(x => x.Name == command.ToLower().Substring(4)))
                {
                    Console.WriteLine("\nUse " + command.Substring(4) + " with?\n");
                    string secondItem = Console.ReadLine();
                    if(currentLocation.getInventory().Exists(x => x.Name == secondItem))
                    {
                        if(secondItem == "window" && command.Substring(4) == "rock")
                        {
                            Item smashedWindow = new Item("smashed window", false, true, "A window frame with broken pieces of glass inside.");
                            currentLocation.addItem(smashedWindow);
                            foreach (Item item in currentLocation.getInventory())
                            {
                                if (item.Name.ToLower() == "window")
                                {
                                    currentLocation.removeItem(item);
                                    break;
                                }

                                if (item.Name.ToLower() == "rock")
                                {
                                    currentLocation.removeItem(item);
                                    break;
                                }

                            }
                            Console.WriteLine("\nYou smash in the window.\n");
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Cannot do the thing.");
                        return;
                    }
                }
                if (currentLocation.getInventory().Exists(x => x.Name == command.ToLower().Substring(4)))
                {
                    if (command.ToLower().Substring(4) == "window")
                    {
                        Console.WriteLine("\nThe window's locked tight, with no way of opening it.\n");
                        return;
                    }
                    if (command.ToLower().Substring(4) == "smashed window")
                    {
                        Console.WriteLine("\nYou clamber out the window. Victory is yours!");
                        _gameOver = true;
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("\nThere is nothing to use.\n");
                    return;
                }
            }

            if(moveRoom(command))
                return;
            
            Console.WriteLine("\nInvalid command, are you confused?\n");
		}

        private bool moveRoom(string command)
        {
            foreach ( Exit exit in currentLocation.getExits() )
            {
                if (command == exit.ToString().ToLower() || command == exit.getShortDirection().ToLower())
                {
                    currentLocation = exit.getLeadsTo();
                    Console.WriteLine("\nYou move " + exit.ToString() + " to the:\n");
                    showLocation();
                    return true;
                }
            }
            return false;
        }


		private void showInventory()
		{
			if ( inventory.Count > 0 )
			{
				Console.WriteLine("\nIn your backpack are the following Items:\n");

				foreach ( Item item in inventory )
				{
					Console.WriteLine(item.Name);
				}
			}
			else
			{
				Console.WriteLine("\nYour backpack is empty.\n");
			}
		}

		public void Update()
		{
			string currentCommand = Console.ReadLine().ToLower();

			// instantly check for a quit
			if (currentCommand == "quit" || currentCommand == "q")
			{
				isRunning = false;
                Console.WriteLine("\nYou left the Game.\n");
				return;
			}


            if (!_gameOver)
            {
                // otherwise, process commands.
                doAction(currentCommand);
            }
            else
            {
                Console.WriteLine("\nNope. Time to quit.\n");
            }			
		}
	}
}