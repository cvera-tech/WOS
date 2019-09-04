using Library.Data;
using LibraryApplication.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryApplication.Pages.Account
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        private const string GetUserAccountQuery = @"
            SELECT
                Id,
                HashedPassword
            FROM UserAccount
            WHERE Username = @Username
        ";
        private const string UpdatePasswordQuery = @"
            UPDATE UserAccount
            SET HashedPassword = @NewPassword
            WHERE Id = @UserId
        ";
        protected void Page_Load(object sender, EventArgs e)
        {
            IncorrectPasswordPanel.Visible = false;
            SuccessPanel.Visible = false;
        }

        protected void SubmitButton_Command(object sender, CommandEventArgs e)
        {
            string username = User.Identity.Name;
            DataTable userTable = DatabaseHelper.Retrieve(
                GetUserAccountQuery,
                new SqlParameter("@Username", username));

            if (userTable.Rows.Count == 1)
            {
                DataRow userRow = userTable.Rows[0];
                string oldPassword = OldPassword.Text;
                string hashedPassword = userRow.Field<string>("HashedPassword");
                if (BCrypt.Net.BCrypt.Verify(oldPassword, hashedPassword))
                {
                    string newPassword = NewPassword.Text;
                    int userId = userRow.Field<int>("Id");
                    string newHashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
                    DatabaseHelper.ExecuteNonQuery(
                        UpdatePasswordQuery,
                        new SqlParameter("@NewPassword", newHashedPassword),
                        new SqlParameter("@UserId", userId));

                    OldPassword.Text = string.Empty;
                    NewPassword.Text = string.Empty;
                    SuccessPanel.Visible = true;
                }
                else
                {
                    IncorrectPasswordPanel.Visible = true;
                }
            }
        }

        protected void CancelButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(SitePages.GetUrl(LibraryPage.Home));
        }

    }
}