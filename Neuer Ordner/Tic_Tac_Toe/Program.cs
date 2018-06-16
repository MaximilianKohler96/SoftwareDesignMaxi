using System;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {

            char[,] matchfield = new char[3, 3];
            matchfield[0, 0] = 'X';
            matchfield[2, 2] = 'O';

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.WriteLine("|    |  X  |    |");
                }
                Console.WriteLine();
            }

            
        }
    }
}
