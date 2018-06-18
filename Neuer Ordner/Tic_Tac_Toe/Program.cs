using System;

namespace Augabe8
{
    class Program
    {
        private const bool V = true;

        static void Main(string[] args)
        {
            char player = 'X';
            char[,] matchfield = new char[3, 3];
            Initialize(matchfield);
            int counter=0;
            int input;
            
            while (true) {
                Console.Clear();
                Print(matchfield);
                Console.Write("Please enter your Pick on the Numpad 1-9  and Press ENTER  ");
                input = Convert.ToInt32(Console.ReadLine());

                if (inputcheck(input)) {
                    int help=9;
                    for (int i=0; i<3; i++) {
                        for (int l=0; l<3; l++) {
                            if (input == help) {
                                if (matchfield[i,2-l] != ' ') {
                                    Console.WriteLine("Your choosen position is already taken. Please choose another one.");
                                    Console.Write("\nPress any key to continue... ");
                                    Console.ReadLine();
                                } else {
                                    matchfield[i,2-l] = player;
                                    player = ChangeTurn(player);
                                    counter++;
                                }
                            }
                        help--;
                        }
                    }
                
                }
                

                if (player == matchfield[0,0] && player == matchfield[0,1] && player == matchfield[0,2])
                {
                    break;
                }

                if (player == matchfield[1,0] && player == matchfield[1,1] && player == matchfield[1,2])
                {
                    break;
                }

                if (player == matchfield[2,0] && player == matchfield[2,1] && player == matchfield[2,2])
                {
                    break;
                }

                if (player == matchfield[0,0] && player == matchfield[1,0] && player == matchfield[2,0])
                {
                    break;
                }

                if (player == matchfield[0,1] && player == matchfield[1,1] && player == matchfield[2,1])
                {
                    break;
                }

                if (player == matchfield[0,2] && player == matchfield[1,2] && player == matchfield[2,2])
                {
                    break;
                }

                if (player == matchfield[0,0] && player == matchfield[1,1] && player == matchfield[2,2])
                {
                    break;
                }

                if (player == matchfield[2,0] && player == matchfield[1,1] && player == matchfield[0,2])
                {
                    break;
                }
                if (counter == 9)
                {
                    break;
                }
                
                
                
            
            }
            Console.Clear();
            Print(matchfield);
            Console.WriteLine("!!  " + player + "  has won the Game  !!");

            if (counter == 9)
            {
                Console.Clear();
                int madebyMaxKundJoscha = ' ';
                Print(matchfield);
                Console.WriteLine("!!  DRAW  !!");
            }
        }

        static bool inputcheck(int inp) {
            if (inp <=9 && inp >= 1) {
                return true;
            } else {
                Console.WriteLine("Your input has to be a number between 1 and 9.");
                Console.Write("\nPress any key to continue... ");
                Console.ReadLine();
            return false;
            }
        }

        static char ChangeTurn(char currentPlayer) {
            if (currentPlayer == 'X' )
                return 'O';
            else
                return 'X';
        }

        static void Initialize(char[,] matchfield)
        {
            for (int row = 0; row < 3; row++)
            {                
                for (int col = 0; col < 3; col++)
                {
                    matchfield[row, col] = ' ';
                }
            }
        }

        static void Print(char[,] matchfield)
        {
            for (int row = 0; row < 3; row++)
            {
                Console.Write("| ");
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(matchfield[row, col]);
                    Console.Write(" | ");
                }
                Console.WriteLine();
            }
        }
    }
}
