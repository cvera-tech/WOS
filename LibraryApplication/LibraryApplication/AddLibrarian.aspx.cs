using Library.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryApplication
{
    public partial class AddLibrarian : System.Web.UI.Page
    {
        private const string LibrariansUrl = "~/Librarians.aspx";
        private const string GetLibrariesQuery = @"
            SELECT Id, Name
            FROM Library
        ";
        private const string GetStatesQuery = @"
            SELECT Id, Abbreviation
            FROM State
        ";
        private const string AddEmployeeQuery = @"
            INSERT INTO Employee (
                FirstName, 
                LastName, 
                LibraryId, 
                AddressLine1, 
                AddressLine2, 
                City, 
                StateId, 
                PostalCode, 
                EmailAddress
            )
            VALUES (
                @FirstName, 
                @LastName, 
                @LibraryId, 
                @AddressLine1, 
                @AddressLine2, 
                @City, @StateId, 
                @PostalCode, 
                @EmailAddress
            )
        ";
        private const string AddLibrarianQuery = @"
            INSERT INTO Librarian (EmployeeId)
            VALUES (@EmployeeId)
        ";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Bind libraries list
                LibraryDropDownList.ListDataSource = () => {
                    DataTable librariesTable = DatabaseHelper.Retrieve(GetLibrariesQuery);
                    LibraryDropDownList.SetTextAndValueFields("Name", "Id");
                    return librariesTable;
                };

                // Bind states list
                StateDropDownList.ListDataSource = () =>
                {
                    DataTable statesTable = DatabaseHelper.Retrieve(GetStatesQuery);
                    StateDropDownList.SetTextAndValueFields("Abbreviation", "Id");
                    return statesTable;
                };
            }
        }

        protected void AddButton_Command(object sender, CommandEventArgs e)
        {
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            int libraryId = int.Parse(LibraryDropDownList.SelectedValue);
            string emailAddress = EmailAddressTextBox.Text;
            string addressLine1 = AddressLine1TextBox.Text;
            string addressLine2 = AddressLine2TextBox.Text;
            string city = CityTextBox.Text;
            int stateId = int.Parse(StateDropDownList.SelectedValue);
            string postalCode = PostalCodeTextBox.Text;
            
            // Insert to Employee first
            int? employeeId = DatabaseHelper.Insert(AddEmployeeQuery,
                new SqlParameter("@FirstName", firstName),
                new SqlParameter("@LastName", lastName),
                new SqlParameter("@LibraryId", libraryId),
                new SqlParameter("@AddressLine1", addressLine1),
                DatabaseHelper.GetNullableStringSqlParameter("@AddressLine2", addressLine2),
                new SqlParameter("@City", city),
                new SqlParameter("@StateId", stateId),
                new SqlParameter("@PostalCode", postalCode),
                new SqlParameter("@EmailAddress", emailAddress));

            // Insert to Librarian
            if (employeeId != null)
            {
                DatabaseHelper.Insert(AddLibrarianQuery,
                    new SqlParameter("@EmployeeId", employeeId));
            }

            Response.Redirect(LibrariansUrl);
        }

        protected void CancelButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(LibrariansUrl);
        }
    }
}