using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UglyTicTacToe.Data
{
    public class TicTacToeData
    {
        private Square[,] GameBoard { get; set; }
        public TicTacToeData(Square[,] gameBoard)
        {
            GameBoard = gameBoard;
        }
        public void ClearGameBoard()
        {
            // Default value of Square is Empty
            GameBoard.Initialize();
        }
    }
}