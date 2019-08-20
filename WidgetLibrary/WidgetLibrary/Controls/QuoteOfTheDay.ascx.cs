using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WidgetLibrary.Data;

namespace WidgetLibrary.Controls
{
    public partial class QuoteOfTheDay : System.Web.UI.UserControl
    {
        public bool Randomize { get; set; } = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            string quoteOfTheDay = Randomize ? QuotesData.GetRandomQuote() : QuotesData.GetQuoteOfTheDay();
            QuoteLabel.Text = quoteOfTheDay;
        }
    }
}