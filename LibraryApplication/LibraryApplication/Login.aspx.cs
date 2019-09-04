using Library.Data;
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
                Id,
                Username,
                HashedPassword
            FROM UserAccount UA
            WHERE Username = @Username
        ";

        protected void SubmitButton_Command(object sender, CommandEventArgs e)
        {
            string username = UserNameTextBox.Text;
            string password = PasswordTextBox.Text;
            
            DataTable userTable = DatabaseHelper.Retrieve(GetUserQuery,
                new SqlParameter("@Username", username));
            if (userTable.Rows.Count == 1)
            {
                DataRow userRow = userTable.Rows[0];
                string hashedPassword = userRow.Field<string>("HashedPassword");
                string hashbrown = BCrypt.Net.BCrypt.HashPassword(password);
                if (BCrypt.Net.BCrypt.Verify(password, hashedPassword))
                {
                    FormsAuthentication.RedirectFromLoginPage(username, false);
                }
            }
            else
            {
                BadLoginMessage.Visible = true;
            }
        }
    }
}