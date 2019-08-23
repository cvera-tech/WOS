using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UglyTicTacToe.Data;

namespace UglyTicTacToe.Controls
{
    public partial class TicTacToe : System.Web.UI.UserControl
    {
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
                //
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            UpdateImageButtons();

            if (GameWon())
            {
                // Player 1 won
                if (CurrentPlayer == Square.X)
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
            else
            {
                if (GameBoardFilled())
                {
                    // Game tied
                    WinImage.Visible = false;
                    PlayerImage.Visible = false;
                    TieImage.Visible = true;
                    GameEndPanel.Visible = true;
                }

                if (IsPostBack)
                {
                    // Switch players
                    CurrentPlayer = (CurrentPlayer == Square.X) ? Square.O : Square.X;
                }
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
        /// Checks if the board has a winning combination.
        /// </summary>
        /// <returns>True if the game is won; false otherwise.</returns>
        private bool GameWon()
        {
            Square[] board = GameBoard;
            // Horizontals
            if ((board[0] != Square.Empty && board[0] == board[3] && board[0] == board[6]) ||
                (board[1] != Square.Empty && board[1] == board[4] && board[1] == board[7]) ||
                (board[2] != Square.Empty && board[2] == board[5] && board[2] == board[8]))
            {
                return true;
            }
            // Verticals
            if ((board[0] != Square.Empty && board[0] == board[1] && board[0] == board[2]) ||
                (board[3] != Square.Empty && board[3] == board[4] && board[3] == board[5]) ||
                (board[6] != Square.Empty && board[6] == board[7] && board[6] == board[8]))
            {
                return true;
            }
            // Diagonals
            if ((board[0] != Square.Empty && board[0] == board[4] && board[0] == board[8]) ||
                (board[2] != Square.Empty && board[2] == board[4] && board[2] == board[6]))
            {
                return true;
            }
            return false;
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