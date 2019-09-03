using Library.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace LibraryApplication
{
    public partial class Login : System.Web.UI.Page
    {
        private const string GetUserQuery = @"
            SELECT
                E.Id,
                E.FirstName + ' ' + E.LastName AS Name,
                E.EmailAddress,
                E.Password
            FROM
                Librarian L
                    JOIN Employee E
                        ON L.EmployeeId = E.Id
            WHERE
                E.EmailAddress = @Username AND
                E.Password = @Password
        ";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Command(object sender, CommandEventArgs e)
        {
            string username = UserNameTextBox.Text;
            string password = PasswordTextBox.Text;
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            DataTable userTable = DatabaseHelper.Retrieve(GetUserQuery,
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password));
            if (userTable.Rows.Count == 1)
            {
                string name = userTable.Rows[0].Field<string>("Name");
                FormsAuthentication.RedirectFromLoginPage(name, false);
            }
            else
            {
                BadLoginMessage.Visible = true;
            }
        }
    }
}