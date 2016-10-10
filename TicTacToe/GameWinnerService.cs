using System;
using TicTacToe.Services;

namespace TicTacToe
{
    public class GameWinnerService : IGameWinnerService
    {
        public char Validate(char[,] gameBoard)
        {
            char winnerCharacter = ' ';

            bool gameBoardIsFull = true;

            //CHECKS ALL THE LINES IN THE CHAR ARRAY
            bool lineIsWinner;
            for (int r = 0; r <= 2; r++)
            {
                lineIsWinner = true;
                for (int c = 1; c <= 2; c++)
                {

                    if (gameBoard[r, c] != gameBoard[r, c - 1])
                    {
                        lineIsWinner = false;
                    }

                }

                if (lineIsWinner == true && gameBoard[r, 0] != ' ')
                {
                    winnerCharacter = gameBoard[r, 0];
                }
            }

            //CHECKS ALL THE ROWS IN THE CHAR ARRAY
            bool rowIsWinner;
            for (int c = 0; c <= 2; c++)
            {
                rowIsWinner = true;
                for (int r = 1; r <= 2; r++)
                {
                    if (gameBoard[r, c] != gameBoard[r-1, c])
                    {
                        rowIsWinner = false;
                    }

                }
                if (rowIsWinner == true && gameBoard[0,c] != ' ')
                {
                    winnerCharacter = gameBoard[0,c];
                }
            }


            //CHECK PRIMARY DIAGONALIS
            bool primDiagonal = true; 

            for(int d = 1; d<=2; d++)
            {
                if(gameBoard[d,d] != gameBoard[d-1,d-1])
                {
                    primDiagonal = false;
                }
            }


            if (primDiagonal == true && gameBoard[0, 0] != ' ')
            {
                winnerCharacter = gameBoard[0, 0];
            }

            //CHECK SECONDARY DIAGONALIS
            bool secDiagonalWinner = true;

            

            int d1 = 1;
            for (int d = 1; d <= 2; d++)
            {
               
                if (gameBoard[d, d1] != gameBoard[d - 1, d1 + 1])
                {
                    secDiagonalWinner = false;
                }
                d1--;
            }

            if (secDiagonalWinner == true && gameBoard[1, 1] != ' ')
            {
                winnerCharacter = gameBoard[1, 1];
            }


            /*Check if we are at the end of the game*/
            foreach (char cell in gameBoard)
            {
                if(cell == ' ')
                {
                    gameBoardIsFull = false;
                }
            }

            if(gameBoardIsFull == true && winnerCharacter == ' ')
            {
                winnerCharacter = 't';
            }

            return winnerCharacter;
        }
    }
}