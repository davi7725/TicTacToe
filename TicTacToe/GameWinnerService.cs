using System;
using TicTacToe.Services;

namespace TicTacToe
{
    internal class GameWinnerService : IGameWinnerService
    {
        public char Validate(char[,] gameBoard)
        {
            char winnerCharacter = ' ';

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
                if(lineIsWinner == true)
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
                if (rowIsWinner == true)
                {
                    winnerCharacter = gameBoard[c, 0];
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


            if (primDiagonal == true)
            {
                winnerCharacter = gameBoard[0, 0];
            }

            //CHECK SECONDARY DIAGONALIS
            bool secDiagonalWinner;

            for (int d = 1; d <= 2; d++)
            {
                secDiagonalWinner = true;
                for (int d1 = 1; d1 >= 0; d1--)
                {
                    if(gameBoard[d,d1] != gameBoard[d-1,d1+1])
                    {
                        secDiagonalWinner = false;
                    }

                }
                if(secDiagonalWinner == true)
                {
                    winnerCharacter = gameBoard[0, 2];
                }
            }


            return winnerCharacter;
        }
    }
}