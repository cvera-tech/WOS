using Library.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryApplication
{
    public partial class EditLibrarian : System.Web.UI.Page
    {
        private const string LibrariansUrl = "~/Librarians.aspx";
        private const string GetLibrariesQuery = @"
            SELECT Id, Name
            FROM Library
            ORDER BY Name
        ";
        private const string GetStatesQuery = @"
            SELECT Id, Abbreviation
            FROM State
        ";
        private const string GetLibrarianQuery = @"
            SELECT
                FirstName,
                LastName,
                LibraryId,
                L2.Name AS LibraryName,
                E.AddressLine1,
                E.AddressLine2,
                E.City,
                E.StateId,
                S.Abbreviation AS StateAbbreviation,
                E.PostalCode,
                EmailAddress
            FROM Librarian L1
                JOIN Employee E
                    ON L1.EmployeeId = E.Id
                JOIN State S
                    On E.StateId = S.Id
                JOIN Library L2
                    ON E.LibraryId = L2.Id
            WHERE L1.Id = @Id
        ";
        private const string EditEmployeeQuery = @"
            UPDATE Employee
            SET 
                FirstName = @FirstName,
                LastName = @LastName,
                LibraryId = @LibraryId,
                AddressLine1 = @AddressLine1,
                AddressLine2 = @AddressLine2,
                City = @City,
                StateId = @StateId,
                PostalCode = @PostalCode,
                EmailAddress = @EmailAddress
            FROM Employee E JOIN Librarian L
            ON E.Id = L.EmployeeId
            WHERE L.Id = @Id
        ";

        private int librarianId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.QueryString["ID"], out librarianId))
            {
                Response.Redirect(LibrariansUrl);
            }

            if (!IsPostBack)
            {
                DataTable librarianTable = DatabaseHelper.Retrieve(GetLibrarianQuery,
                    new SqlParameter("@Id", librarianId));
                if (librarianTable.Rows.Count == 1)
                {
                    DataRow librarianRow = librarianTable.Rows[0];
                    string oldFirstName = librarianRow.Field<string>("FirstName");
                    string oldLastName = librarianRow.Field<string>("LastName");
                    int oldLibraryId = librarianRow.Field<int>("LibraryId");
                    string oldLibrary = librarianRow.Field<string>("LibraryName");
                    string oldAddressLine1 = librarianRow.Field<string>("AddressLine1");
                    string oldAddressLine2 = librarianRow.Field<string>("AddressLine2");
                    string oldCity = librarianRow.Field<string>("City");
                    int oldStateId = librarianRow.Field<int>("StateId");
                    string oldState = librarianRow.Field<string>("StateAbbreviation");
                    string oldPostalCode = librarianRow.Field<string>("PostalCode");
                    string oldEmailAddress = librarianRow.Field<string>("EmailAddress");

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
                    OldName.Text = oldFirstName + " " + oldLastName;
                    OldEmailAddress.Text = oldEmailAddress;
                    OldLibrary.Text = oldLibrary;
                    OldAddress.Text = formattedAddress.ToString();
                    NewFirstNameTextBox.Text = oldFirstName;
                    NewLastNameTextBox.Text = oldLastName;
                    NewEmailAddressTextBox.Text = oldEmailAddress;
                    NewLibraryDropDownList.ListDataSource = () =>
                    {
                        DataTable librariesTable = DatabaseHelper.Retrieve(GetLibrariesQuery);
                        NewLibraryDropDownList.SetTextAndValueFields("Name", "Id");
                        return librariesTable;
                    };
                    NewLibraryDropDownList.SelectedValue = oldLibraryId.ToString();
                    NewAddressLine1TextBox.Text = oldAddressLine1;
                    NewAddressLine2TextBox.Text = (oldAddressLine2 ?? string.Empty);
                    NewCityTextBox.Text = oldCity;
                    NewStateDropDownList.ListDataSource = () =>
                    {
                        DataTable statesTable = DatabaseHelper.Retrieve(GetStatesQuery);
                        NewStateDropDownList.SetTextAndValueFields("Abbreviation", "Id");
                        return statesTable;
                    };
                    NewStateDropDownList.SelectedValue = oldStateId.ToString();
                    NewPostalCodeTextBox.Text = oldPostalCode;
                }


            }
        }

        protected void SaveButton_Command(object sender, CommandEventArgs e)
        {
            string firstName = NewFirstNameTextBox.Text;
            string lastName = NewLastNameTextBox.Text;
            int libraryId = int.Parse(NewLibraryDropDownList.SelectedValue);
            string emailAddress = NewEmailAddressTextBox.Text;
            string addressLine1 = NewAddressLine1TextBox.Text;
            string addressLine2 = NewAddressLine2TextBox.Text;
            string city = NewCityTextBox.Text;
            int stateId = int.Parse(NewStateDropDownList.SelectedValue);
            string postalCode = NewPostalCodeTextBox.Text;

            //FirstName = @FirstName,
            //    LastName = @LastName,
            //    LibraryId = @LibraryId,
            //    AddressLine1 = @AddressLine1,
            //    AddressLine2 = @AddressLine2,
            //    City = @City,
            //    StateId = @StateId,
            //    PostalCode = @PostalCode,
            //    EmailAddress = @EmailAddress
            //FROM Employee E JOIN Librarian L
            //ON E.Id = L.EmployeeId
            //WHERE L.Id = @Id

            DatabaseHelper.ExecuteNonQuery(EditEmployeeQuery,
                new SqlParameter("@FirstName", firstName),
                new SqlParameter("@LastName", lastName),
                new SqlParameter("@LibraryId", libraryId),
                new SqlParameter("@AddressLine1", addressLine1),
                DatabaseHelper.GetNullableStringSqlParameter("@AddressLine2", addressLine2),
                new SqlParameter("@City", city),
                new SqlParameter("@StateId", stateId),
                new SqlParameter("@PostalCode", postalCode),
                new SqlParameter("@EmailAddress", emailAddress),
                new SqlParameter("@Id", librarianId)
            );

            Response.Redirect(LibrariansUrl);
        }

        protected void CancelButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(LibrariansUrl);
        }
    }
}