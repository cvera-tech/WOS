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

        private Square[,] GameBoard
        {
            get
            {
                object o = ViewState["GameBoard"];
                return o != null ? (Square[,])o : new Square[3, 3];
            }
            set
            {
                ViewState["GameBoard"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // default(Square) is Square.Empty
                GameBoard = new Square[3,3];
                GameBoard[0, 0] = Square.O;
                GameBoard[0, 1] = Square.X;
                GameBoard[0, 2] = Square.X;
                GameBoard[1, 0] = Square.O;
                GameBoard[1, 1] = Square.O;
                GameBoard[1, 2] = Square.X;
                GameBoard[2, 0] = Square.O;
                GameBoard[2, 1] = Square.O;
                GameBoard[2, 2] = Square.X;
                UpdateImageButtons();
            }
        }

        private void UpdateImageButtons()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    var square = GameBoard[row, col];
                    var imageButtonId = $"Square{row}{col}";
                    var imageUrl = string.Empty;
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
                    ImageButton imageButton = (ImageButton)FindControl(imageButtonId);
                    imageButton.ImageUrl = imageUrl;
                }
            }
        }
        
        protected void Square_Command(object sender, CommandEventArgs e)
        {

        }

        protected void Reset_Command(object sender, CommandEventArgs e)
        {

        }
    }
}