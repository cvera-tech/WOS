﻿using Library.Data;
using LibraryApplication.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryApplication.Pages.Libraries
{
    public partial class Add : System.Web.UI.Page
    {
        private string LibrariesUrl = SitePages.GetUrl(LibraryPage.Libraries);
        private const string AddLibraryQuery = @"
            INSERT INTO Library (Name, AddressLine1, AddressLine2, City, StateId, PostalCode)
            VALUES (
                @Name,
                @AddressLine1,
                @AddressLine2,
                @City,
                @StateId,
                @PostalCode
            )
        ";
        private string GetStatesQuery = @"
            SELECT Id, Abbreviation
            FROM State
        ";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.IsInRole("Librarian"))
            {
                Response.Redirect(SitePages.GetUrl(LibraryPage.NotAuthorized));
            }
            if (!IsPostBack)
            {
                StateDropDown.ListDataSource = () => 
                {
                    DataTable states = DatabaseHelper.Retrieve(GetStatesQuery);
                    StateDropDown.SetTextAndValueFields("Abbreviation", "Id");
                    return states;
                };
            }
        }

        protected void AddButton_Command(object sender, CommandEventArgs e)
        {
            if (Page.IsValid)
            {
                string name = NameTextBox.Text;
                string addressLine1 = AddressLine1TextBox.Text;
                string addressLine2 = AddressLine2TextBox.Text;
                string city = CityTextBox.Text;
                int stateId = int.Parse(StateDropDown.SelectedValue);
                string postalCode = PostalCodeTextBox.Text;

                DatabaseHelper.ExecuteNonQuery(AddLibraryQuery,
                    new SqlParameter("@Name", name),
                    new SqlParameter("@AddressLine1", addressLine1),
                    DatabaseHelper.GetNullableStringSqlParameter("@AddressLine2", addressLine2),
                    new SqlParameter("@City", city),
                    new SqlParameter("@StateId", stateId),
                    new SqlParameter("@PostalCode", postalCode));

                Response.Redirect(LibrariesUrl);
            }
        }

        protected void CancelButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(LibrariesUrl);
        }
    }
}