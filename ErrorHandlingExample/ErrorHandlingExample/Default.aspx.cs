using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ErrorHandlingExample
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Sum_Click(object sender, EventArgs e)
        {
            int number1, number2, sum;
            if (int.TryParse(Number1.Text, out number1) && int.TryParse(Number2.Text, out number2))
            {
                sum = number1 + number2;
                System.Diagnostics.Debug.Assert(sum != 21);
                Result.Text = sum.ToString();
                Trace.Write("Sum_click", sum.ToString());
            }
            else
            {
                Trace.Warn("Sum_Click", "Unable to parse input");
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}