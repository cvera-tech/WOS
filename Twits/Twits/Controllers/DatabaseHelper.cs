using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Twits.Controllers
{
    public static class DatabaseHelper
    {
        private const string DatabaseName = "TwitDatabase";
        public static DataTable Retrieve(string sql, params SqlParameter[] parameters)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;

            DataTable dt = new DataTable();

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(sql, connection);

                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }

                var dataAdapter = new SqlDataAdapter(command);

                // This is where the work is happening.
                dataAdapter.Fill(dt);
            }

            return dt;
        }

        public static int? Insert(string sql, params SqlParameter[] parameters)
        {
            sql += @"
                select cast(scope_identity() as int) as 'id';
            ";

            string ConnectionString = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;

            int? id = null;

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(sql, connection);

                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }

                // This is where the work is happening.
                command.Connection.Open();
                id = (int?)command.ExecuteScalar();
            }

            return id;
        }

        public static void ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(sql, connection);

                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }

                // This is where the work is happening.
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static void Update(string sql, params SqlParameter[] parameters)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(sql, connection);

                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }

                // This is where the work is happening.
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static SqlParameter GetNullableStringSqlParameter(string parameterName, string value)
        {
            return new SqlParameter(parameterName, string.IsNullOrWhiteSpace(value) ? (object)DBNull.Value : value);
        }

        /// <summary>
        /// This doesn't work because the connection is closed upon return
        /// </summary>
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] parameters)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
            SqlDataReader dataReader;

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(sql, connection);

                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }

                // This is where the work is happening.
                command.Connection.Open();
                dataReader = command.ExecuteReader();
            }
            return dataReader;
        }
    }
}