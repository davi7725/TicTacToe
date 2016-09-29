using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.Services;

namespace TicTacToe
{
    [TestClass]
    public class GameWinnerServiceTests
    {
        private GameWinnerService _gameWinnerService;
        private char[,] _gameBoard;

        [TestInitialize]
        public void SetUpUnitTests()
        {
            _gameWinnerService = new GameWinnerService();
            _gameBoard = new char[3, 3] { {' ',' ',' ' },
                                             {' ',' ',' ' },
                                             { ' ',' ',' '} };
        }
        [TestMethod]
        public void NeitherPlayerHasThreeInARow()
        {
            const char expected = ' ';
            IGameWinnerService gameWinnerService;
            gameWinnerService = new GameWinnerService();
            char[,] gameBoard = new char[3, 3] { {' ',' ',' ' },
                                             {' ',' ',' ' },
                                             { ' ',' ',' '} };

            char actual = gameWinnerService.Validate(gameBoard);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PlayerWithAllSpacesInTopRowIsWinner()
        {
            IGameWinnerService gameWinnerService;
            gameWinnerService = new GameWinnerService();
            const char expected = 'X';
            char[,] gameBoard = new char[3, 3] { {expected,expected,expected },
                                             {' ',' ',' ' },
                                             { ' ',' ',' '} };
            char actual = gameWinnerService.Validate(gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void PlayerWithAllSpacesInFirstColumnIsWinner()
        {
            const char expected = 'X';
            for(var columnIndex = 0; columnIndex <3; columnIndex++)
            {
                _gameBoard[columnIndex, 0] = expected;
            }
            char actual = _gameWinnerService.Validate(_gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void PlayerWithThreeInARowDiagonallyDownAndToRightIsWinner()
        {
            const char expected = 'X';
            for (var cellIndex = 0; cellIndex < 3; cellIndex++)
            {
                _gameBoard[cellIndex, cellIndex] = expected;
            }
            char actual = _gameWinnerService.Validate(_gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void PlayerWithThreeInARowDiagonallyUpAndToLeftIsWinner()
        {
            const char expected = 'X';
            int cellIndex2 = 2;
            for (var cellIndex = 0; cellIndex < 3; cellIndex++)
            {
                _gameBoard[cellIndex, cellIndex2] = expected;
                cellIndex2--;
            }
            char actual = _gameWinnerService.Validate(_gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
    }
}
