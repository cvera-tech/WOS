using Blahgger.Models;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Security;

namespace Blahgger.Data
{
    /// <summary>
    /// This class contains methods for binding data from the database to models.
    /// </summary>
    public class BlahggerData
    {
        private static BlahggerData singleton = null;

        private BlahggerData() { }

        public static BlahggerData GetInstance()
        {
            if (singleton == null)
            {
                singleton = new BlahggerData();
            }
            return singleton;
        }
        
        public void AddUser(User user)
        {
            string sql = @"
                INSERT INTO Users (Username, HashedPassword)
                VALUES (@Username, @HashedPassword)
            ";
            // TODO Password hashing

            DatabaseHelper.Insert(sql,
                new SqlParameter("@Username", user.Username),
                new SqlParameter("@HashedPassword", user.HashedPassword));

        }

        internal int GetUsersId(string username)
        {
            string sql = @"
                SELECT Id
                FROM Users
                WHERE Username=@Username
            ";

            DataTable userTable = DatabaseHelper.Retrieve(sql,
                new SqlParameter("@Username", username));
            if (userTable.Rows.Count == 1)
            {
                return userTable.Rows[0].Field<int>("Id");
            }
            else
            {
                throw new Exception("SELECT query returned unexpected number of rows");
            }
        }

        /// <summary>
        /// This method checks whether or not a user's credentials match a row in the database.
        /// </summary>
        /// <param name="user">The input user object. This is assumed to have non-null Username and HashedPassword properties.</param>
        /// <returns>True if a match is found; false otherwise.</returns>
        internal bool AuthenticateUser(User user)
        {
            string sql = @"
                SELECT HashedPassword
                FROM Users
                WHERE Username=@Username
            ";

            DataTable userTable = DatabaseHelper.Retrieve(sql,
                new SqlParameter("@Username", user.Username));
            if (userTable.Rows.Count == 1)
            {
                string tablePassword = userTable.Rows[0].Field<string>("HashedPassword");
                string inputPassword = user.HashedPassword;
                if (tablePassword.Equals(inputPassword))
                {
                    // Create a vanilla authentication ticket
                    //FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(user.Username,false,30);

                    // Set an authentication cookie
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    return true;
                }
            }
            return false;
        }

        internal void AddPost(Post post)
        {
            string sql = @"
                INSERT INTO Posts (Text, CreatedOn, UsersId)
                VALUES (@Text, @CreatedOn, @UsersId)
            ";

            DatabaseHelper.Insert(sql,
                new SqlParameter("@Text", post.Text),
                new SqlParameter("@CreatedOn", post.CreatedOn),
                new SqlParameter("@UsersId", post.UsersId));
        }

        internal List<Post> GetPosts()
        {
            string sql = @"
                SELECT 
                    P.Id, 
                    Text, 
                    CreatedOn,
                    UsersId,
                    Username
                FROM
                    Posts P JOIN Users U
                        ON P.UsersId = U.Id
            ";
            DataTable postsTable = DatabaseHelper.Retrieve(sql);
            List<Post> posts = new List<Post>();
            foreach (DataRow row in postsTable.Rows)
            {
                Post post = new Post()
                {
                    Id = row.Field<int>("Id"),
                    Text = row.Field<string>("Text"),
                    CreatedOn = row.Field<DateTimeOffset>("CreatedOn"),
                    UsersId = row.Field<int>("UsersId"),
                    Username = row.Field<string>("Username")
                };
                posts.Add(post);
            }
            return posts;
        }
    }
}