using Blahgger.Models;
using System.Data.SqlClient;

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

        public bool AddUser(User user)
        {
            //try
            //{
                string sql = @"
                    INSERT INTO Users (Username, HashedPassword)
                    VALUES (@Username, @HashedPassword)
                ";
                // TODO Password hashing

                DatabaseHelper.Insert(sql,
                    new SqlParameter("@Username", user.Username),
                    new SqlParameter("@HashedPassword", user.HashedPassword));

                return true;
            //}
            //catch
            //{
            //    return false;
            //}
        }
    }
}