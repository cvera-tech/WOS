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
        private const string PlayerString = "Player";
        private const string GameBoardString = "GameBoard";
        private Square CurrentPlayer
        {
            get
            {
                object o = ViewState[PlayerString];
                if (o != null)
                {
                    //string indexString = o.ToString();
                    //return (Square)(Enum.Parse(typeof(Square), indexString));
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

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            UpdateImageButtons();
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
            // Switch players
            CurrentPlayer = (CurrentPlayer == Square.X) ? Square.O : Square.X;
        }

        protected void Reset_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("~/");
        }
    }
}