using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UglyTicTacToe.Data;
using UglyTicTacToe.Code;

namespace UglyTicTacToe.Controls
{
    public partial class TicTacToe : System.Web.UI.UserControl
    {
        public bool VersusAI { get; set; }
        private const string BlankUrl = "~/Images/deepfriedBlank.png";
        private const string OUrl = "~/Images/deepfriedO.png";
        private const string XUrl = "~/Images/deepfriedX.png";
        private const string Player1Url = "~/Images/deepfriedPlayer1.png";
        private const string Player2Url = "~/Images/deepfriedPlayer2.png";
        private const string PlayerString = "Player";
        private const string GameBoardString = "GameBoard";
        private Square CurrentPlayer
        {
            get
            {
                object o = ViewState[PlayerString];
                if (o != null)
                {
                    return (Square)o;
                }
                else
                {
                    return Square.X;
                }
            }
            set
            {
                ViewState[PlayerString] = value;
            }
        }

        private Square[] GameBoard
        {
            get
            {
                object o = ViewState[GameBoardString];
                if (o != null)
                {
                    return (Square[])o;
                }
                else
                {
                    ViewState[GameBoardString] = new Square[9];
                    return new Square[9];
                }
            }
            set
            {
                ViewState[GameBoardString] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GameEndPanel.Visible = false;
                WinImage.Visible = false;
                PlayerImage.Visible = false;
                TieImage.Visible = false;
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (VersusAI)
            {
                HandleVersusAI();
            }
            else
            {
                HandlePvP();
            }
        }

        /// <summary>
        /// Iterates through the game board and sets the ImageUrl of each square.
        /// </summary>
        private void UpdateImageButtons()
        {
            for (int index = 0; index < 9; index++)
            {
                var row = index / 3;
                var col = index % 3;
                var square = GameBoard[index];
                var imageButtonId = $"Square{row}{col}";
                var imageUrl = string.Empty;
                ImageButton imageButton = (ImageButton)FindControl(imageButtonId);
                switch (square)
                {
                    case Square.Empty:
                        imageUrl = BlankUrl;
                        break;
                    case Square.O:
                        imageUrl = OUrl;
                        break;
                    case Square.X:
                        imageUrl = XUrl;
                        break;
                }
                imageButton.ImageUrl = imageUrl;

                if (square != Square.Empty)
                {
                    imageButton.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Checks the game board for a winning combination and returns the winner.
        /// </summary>
        /// <returns>The player who won or Square.Empty if there is no winner.</returns>
        private Square GetWinner()
        {
            Square[,] board2D = UnbeatableAI.To2DArray(GameBoard);

            // Check rows
            for (int row = 0; row < 3; row++)
            {
                if (board2D[row, 0] == board2D[row, 1] &&
                    board2D[row, 1] == board2D[row, 2] &&
                    board2D[row, 0] != Square.Empty)
                {
                    return board2D[row, 0];
                }
            }

            // Check columns
            for (int col = 0; col < 3; col++)
            {
                if (board2D[0, col] == board2D[1, col] &&
                    board2D[1, col] == board2D[2, col] &&
                    board2D[0, col] != Square.Empty)
                {
                    return board2D[0, col];
                }
            }

            // Check diagonals
            if ((board2D[0, 0] == board2D[1, 1] && board2D[1, 1] == board2D[2, 2] ||
                 board2D[0, 2] == board2D[1, 1] && board2D[1, 1] == board2D[2, 0]) &&
                 board2D[1, 1] != Square.Empty)
            {
                return board2D[1, 1];
            }
            return Square.Empty;
        }

        /// <summary>
        /// Checks if the game board is completely filled.
        /// </summary>
        /// <returns>True if the board is filled; false otherwise.</returns>
        private bool GameBoardFilled()
        {
            foreach (var square in GameBoard)
            {
                if (square == Square.Empty)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Takes player input and updates the game board accordingly.
        /// On Post Back, switches the active player.
        /// </summary>
        private void HandlePvP()
        {
            UpdateImageButtons();
            // Check for winning condition
            Square winner = GetWinner();
            if (winner != Square.Empty)
            {
                WonGameImage(winner);
            }

            // Check if game is tied
            else if (GameBoardFilled())
            {
                TiedGameImage();
            }

            else if (IsPostBack)
            {
                // Switch players
                CurrentPlayer = (CurrentPlayer == Square.X) ? Square.O : Square.X;
            }
        }

        private void HandleVersusAI()
        {
            // Human player always has first move
            if (IsPostBack)
            {
                int computerMove = UnbeatableAI.GetBestMove(GameBoard);
                if (computerMove >= 0)
                {
                    //CurrentPlayer = Square.O;
                    GameBoard[computerMove] = Square.O;
                }
            }

            UpdateImageButtons();

            // Check for game win
            Square winner = GetWinner();
            if (winner != Square.Empty)
            {
                WonGameImage(winner);
            }

            else if (GameBoardFilled())
            {
                TiedGameImage();
            }
        }

        private void TiedGameImage()
        {
            WinImage.Visible = false;
            PlayerImage.Visible = false;
            TieImage.Visible = true;
            GameEndPanel.Visible = true;
        }

        private void WonGameImage(Square winner)
        {
            // Player 1 won
            if (winner == Square.X)
            {
                PlayerImage.ImageUrl = Player1Url;
            }
            // Player 2 won
            else
            {
                PlayerImage.ImageUrl = Player2Url;
            }
            GameEndPanel.Visible = true;
            WinImage.Visible = true;
            PlayerImage.Visible = true;

            // Disable all ImageButtons
            for (int index = 0; index < 9; index++)
            {
                var row = index / 3;
                var col = index % 3;
                var square = GameBoard[index];
                var imageButtonId = $"Square{row}{col}";
                ImageButton imageButton = (ImageButton)FindControl(imageButtonId);
                imageButton.Enabled = false;
            }
        }

        protected void Square_Command(object sender, CommandEventArgs e)
        {
            var coords = (string)e.CommandArgument;
            var rowString = coords.Substring(0, 1);
            var colString = coords.Substring(1, 1);
            var row = int.Parse(rowString);
            var col = int.Parse(colString);
            var index = row * 3 + col;
            // Update the game board
            GameBoard[index] = CurrentPlayer;
        }

        protected void Reset_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("~/");
        }
    }
}