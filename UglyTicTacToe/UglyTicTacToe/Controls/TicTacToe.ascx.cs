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
                GameBoard.Initialize();
            }
        }

        private void UpdateImageButtons()
        {
            ControlCollection allControls = Page.Controls;
            Square00.ImageUrl = "";
            //for (int row = 0; row < 3; row++)
            //{
            //    for (int col = 0; col < 3; col++)
            //    {
            //        var square = GameBoard[row, col];
            //        var imgID = $"Square{row}{col}";
            //        switch (square)
            //        {
            //            case Square.Empty:
            //                break;
            //            case Square.O:
            //                break;
            //            case Square.X:
            //                break;
            //        }
            //    }
            //}
        }

        private List<ImageButton> GetImageButtons()
        {
            var list = new List<ImageButton>();
            ControlCollection allControls = Page.Controls;
            //list.AddRange()
            return list;
        }
        
        protected void Square_Command(object sender, CommandEventArgs e)
        {

        }

        protected void Reset_Command(object sender, CommandEventArgs e)
        {

        }
    }
}