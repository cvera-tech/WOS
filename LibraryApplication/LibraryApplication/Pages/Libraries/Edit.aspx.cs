using Library.Data;
using LibraryApplication.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryApplication.Pages.Libraries
{
    public partial class Edit : System.Web.UI.Page
    {
        private string LibrariesUrl = SitePages.GetUrl(LibraryPage.Libraries);
        private const string GetStatesQuery = @"
            SELECT Id, Abbreviation
            FROM State
        ";
        private const string GetLibraryQuery = @"
            SELECT
	            l.Name,
	            AddressLine1,
	            AddressLine2,
	            City,
	            s.Abbreviation as StateAbbreviation,
                s.Id as StateId,
	            PostalCode
            FROM Library l JOIN State s
            ON l.StateId = s.Id
            WHERE l.Id = @Id
        ";
        private const string EditLibraryQuery = @"
            Update Library
            SET
                Name=@Name,
                AddressLine1=@AddressLine1,
                AddressLine2=@AddressLine2,
                City=@City,
                StateId=@StateId,
                PostalCode=@PostalCode
            WHERE Id=@Id
        ";

        private int libraryId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.QueryString["ID"], out libraryId))
            {
                Response.Redirect(LibrariesUrl);
            }

            if (!IsPostBack)
            {
                DataTable libraryTable = DatabaseHelper.Retrieve(GetLibraryQuery,
                    new SqlParameter("@Id", libraryId));
                if (libraryTable.Rows.Count == 1)
                {
                    DataRow row = libraryTable.Rows[0];
                    string oldName = row.Field<string>("Name");
                    string oldAddressLine1 = row.Field<string>("AddressLine1");
                    string oldAddressLine2 = row.Field<string>("AddressLine2");
                    string oldCity = row.Field<string>("City");
                    string oldState = row.Field<string>("StateAbbreviation");
                    int oldStateId = row.Field<int>("StateId");
                    string oldPostalCode = row.Field<string>("PostalCode");

                    // Format address for OldAddress label
                    StringBuilder formattedAddress = new StringBuilder();
                    formattedAddress.Append(oldAddressLine1);
                    if (oldAddressLine2 != null)
                    {
                        formattedAddress.Append(" " + oldAddressLine2);
                    }
                    formattedAddress.Append(", " + oldCity);
                    formattedAddress.Append(", " + oldState);
                    formattedAddress.Append(" " + oldPostalCode);

                    // Fill in all controls in the page
                    OldName.Text = oldName;
                    OldAddress.Text = formattedAddress.ToString();
                    NewNameTextBox.Text = oldName;
                    NewAddressLine1TextBox.Text = oldAddressLine1;
                    NewAddressLine2TextBox.Text = (oldAddressLine2 ?? string.Empty);
                    NewCityTextBox.Text = oldCity;
                    NewStateDropDown.ListDataSource = () =>
                    {
                        DataTable dt = DatabaseHelper.Retrieve(GetStatesQuery);
                        NewStateDropDown.SetTextAndValueFields("Abbreviation", "Id");
                        return dt;
                    };
                    NewStateDropDown.SelectedValue = oldStateId.ToString();
                    NewPostalCodeTextBox.Text = oldPostalCode;
                }
            }
        }

        protected void SaveButton_Command(object sender, CommandEventArgs e)
        {
            if (Page.IsValid)
            {
                string name = NewNameTextBox.Text;
                string addressLine1 = NewAddressLine1TextBox.Text;
                string addressLine2 = NewAddressLine2TextBox.Text;
                string city = NewCityTextBox.Text;
                int stateId = int.Parse(NewStateDropDown.SelectedValue);
                string postalCode = NewPostalCodeTextBox.Text;

                DatabaseHelper.ExecuteNonQuery(EditLibraryQuery,
                    new SqlParameter("@Id", libraryId),
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