using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe;


namespace TicTacToeUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Run();
        }

        public void Run()
        {
            GameWinnerService validator = new GameWinnerService();

            char[,] gameBoard = new char[3, 3] { {' ',' ',' ' },
                                                 {' ',' ',' ' },
                                                 { ' ',' ',' '} };

            bool isFirstPlayer = true;

            while (validator.Validate(gameBoard) == ' ')
            {

                printGame(gameBoard);


                int x = getInput();
                int y = getInput();

                while (isPositionOccupied(gameBoard, x, y) == true)
                {
                    Console.Clear();
                    printGame(gameBoard);
                    Console.WriteLine("Bad input! Try again");
                    x = getInput();
                    y = getInput();
                }

                if (isFirstPlayer == true)
                {

                    gameBoard[x, y] = 'x';
                    isFirstPlayer = false;
                }
                else
                {
                    gameBoard[x, y] = 'o';
                    isFirstPlayer = true;
                }
                Console.Clear();

            }
            if (validator.Validate(gameBoard) == 't')
            {
                Console.WriteLine("No winner!! Try again.");
            }
            else
            {
                Console.WriteLine("Congratulations, " + validator.Validate(gameBoard) + " you WON!!");
            }

            Console.ReadKey();
        }

        private void printGame(char[,] gameBoardInsideMethod)
        {
            Console.WriteLine("| " + gameBoardInsideMethod[0, 0] + " | " + gameBoardInsideMethod[0, 1] + " | " + gameBoardInsideMethod[0, 2] + " | ");
            Console.WriteLine("| " + gameBoardInsideMethod[1, 0] + " | " + gameBoardInsideMethod[1, 1] + " | " + gameBoardInsideMethod[1, 2] + " | ");
            Console.WriteLine("| " + gameBoardInsideMethod[2, 0] + " | " + gameBoardInsideMethod[2, 1] + " | " + gameBoardInsideMethod[2, 2] + " | ");
        }



        private int getInput()
        {
            Console.WriteLine("In which position would you like to write?");
            string input = Console.ReadLine();

            int returnedInput = Convert.ToInt32(input);

            return returnedInput;

        }

        private bool isPositionOccupied(char[,] gameBoardInsideMethod, int x, int y)
        {
            bool isOccupied = true;
            if (x <= 2 && x>=0 && y <= 2 && y>=0)
            {
                if (gameBoardInsideMethod[x, y] != ' ')
                {
                    isOccupied = true;
                }
                else
                {
                    isOccupied = false;
                }
            }


            return isOccupied;
        }

    }
}
