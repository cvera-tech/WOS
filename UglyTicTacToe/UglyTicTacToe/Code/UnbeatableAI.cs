﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UglyTicTacToe.Data;

namespace UglyTicTacToe.Code
{
    /// <summary>
    /// This is an implementation of a Tic-Tac-Toe AI using the Minimax algorithm.
    /// It was adapted from Akshay L Aradhya's article on GeeksForGeeks.org:
    /// https://www.geeksforgeeks.org/minimax-algorithm-in-game-theory-set-3-tic-tac-toe-ai-finding-optimal-move/
    /// </summary>
    public static class UnbeatableAI
    {
        /// <summary>
        /// Builds and returns a 2D Square array from a 1D Square array
        /// </summary>
        /// <param name="array">The 1D Square array.</param>
        /// <returns>The 2D Square array.</returns>
        public static Square[,] To2DArray(Square[] array)
        {
            var array2D = new Square[3, 3];
            for (int index = 0; index < array.Length; index++)
            {
                var row = index / 3;
                var col = index % 3;
                array2D[row, col] = array[index];
            }
            return array2D;
        }

        /// <summary>
        /// Checks if the board has any empty squares remaining.
        /// </summary>
        /// <param name="board">The game board.</param>
        /// <returns>True if there are any empty squares; false otherwise.</returns>
        private static bool HasMovesLeft(Square[,] board)
        {
            foreach (var square in board)
            {
                if (square == Square.Empty)
                {
                    return true;
                }
            }
            return false;
        }
        
        /// <summary>
        /// Checks the game board and returns a score for the minimax algorithm.
        /// </summary>
        /// <param name="board">The game board.</param>
        /// <returns>Positive integer if AI won; negative integer if player won. Zero otherwise.</returns>
        private static int Evaluate(Square[,] board)
        {
            const Square computer = Square.O;
            const Square player = Square.X;

            // Check rows
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] == board[row, 1] &&
                    board[row, 1] == board[row, 2])
                {
                    if (board[row, 0] == player)
                    {
                        return -10;
                    }
                    else if (board[row, 0] == computer)
                    {
                        return +10;
                    }
                }
            }

            // Check columns
            for (int col = 0; col < 3; col++)
            {
                if (board[0, col] == board[1, col] &&
                    board[1, col] == board[2, col])
                {
                    if (board[0, col] == player)
                    {
                        return -10;
                    }

                    else if (board[0, col] == computer)
                    {
                        return +10;
                    }
                }
            }

            // Checking for Diagonals for X or O victory. 
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                if (board[0, 0] == player)
                {
                    return -10;
                }
                else if (board[0, 0] == computer)
                {
                    return +10;
                }
            }

            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                if (board[0, 2] == player)
                {
                    return -10;
                }
                else if (board[0, 2] == computer)
                {
                    return +10;
                }
            }

            // Else if none of them have won then return 0 
            return 0;
        }

        /// <summary>
        /// Considers all the possible ways the game can go 
        /// and returns the value of the board.
        /// </summary>
        /// <param name="board">The game board.</param>
        /// <param name="depth">The current iteration of the recursive algorithm.</param>
        /// <param name="isMax">True if it is the AI's turn for the current iteration. False otherwise.</param>
        /// <returns>The value of the board.</returns>
        // 
        private static int Minimax(Square[,] board, int depth, bool isMax)
        {
            const Square computer = Square.O;
            const Square player = Square.X;

            int score = Evaluate(board);

            // If Maximizer has won the game return his/her 
            // evaluated score 
            if (score == 10)
                return score;

            // If Minimizer has won the game return his/her 
            // evaluated score 
            if (score == -10)
                return depth;

            // If there are no more moves and no winner then 
            // it is a tie 
            if (!HasMovesLeft(board))
                return 0;

            if (isMax)
            {
                int best = -1000;
                // Traverse all cells 
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        // Check if cell is empty 
                        if (board[i, j] == Square.Empty)
                        {
                            // Make the move 
                            board[i, j] = computer;

                            // Call minimax recursively and choose 
                            // the minimum value 
                            best = Math.Max(best, Minimax(board, depth + 1, !isMax));

                            // Undo the move 
                            board[i, j] = Square.Empty;
                        }
                    }
                }
                return best;
            }
            else
            {
                int best = 1000;
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        if (board[row,col] == Square.Empty)
                        {
                            board[row, col] = player;
                            best = Math.Min(best, Minimax(board, depth + 1, !isMax));
                            board[row, col] = Square.Empty;
                        }
                    }
                }
                return best;
            }

        }

        /// <summary>
        /// Calculates and returns the index of the best possible move 
        /// for the AI using the minimax algorithm.
        /// </summary>
        /// <param name="board">The game board.</param>
        /// <returns>The index of the move.</returns>
        public static int GetBestMove(Square[] board)
        {
            const Square player = Square.X;
            const Square computer = Square.O;

            Square[,] board2d = To2DArray(board);

            int bestVal = -1000;
            int bestRow = -1;
            int bestCol = -1;

            // Traverse all cells, evaluate minimax function for 
            // all empty cells. And return the cell with optimal 
            // value. 
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    // Check if cell is empty 
                    if (board2d[row, col] == Square.Empty)
                    {
                        // Make the move 
                        board2d[row, col] = computer;

                        // compute evaluation function for this 
                        // move. 
                        int moveVal = Minimax(board2d, 0, false);

                        // Undo the move 
                        board2d[row, col] = Square.Empty;

                        // If the value of the current move is 
                        // more than the best value, then update 
                        // best/ 
                        if (moveVal > bestVal)
                        {
                            bestRow = row;
                            bestCol = col;
                            bestVal = moveVal;
                        }
                    }
                }
            }
            int bestIndex = bestRow * 3 + bestCol;
            return bestIndex;
        }
    }
}