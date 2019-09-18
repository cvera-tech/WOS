using Library.Data;
using LibraryApplication.Data;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace LibraryApplication.Pages.Patrons
{
    public partial class Add : System.Web.UI.Page
    {
        private const string GetStatesQuery = @"
            SELECT Id, Abbreviation
            FROM State
        ";
        protected void Page_Load(object sender, EventArgs e)
        {
            StateDropDownList.ListDataSource = () =>
            {
                DataTable statesTable = DatabaseHelper.Retrieve(GetStatesQuery);
                StateDropDownList.SetTextAndValueFields("Abbreviation", "Id");
                return statesTable;
            };
        }

        protected void AddButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(SitePages.GetUrl(LibraryPage.Patrons));
        }

        protected void CancelButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(SitePages.GetUrl(LibraryPage.Patrons));
        }
    }
}