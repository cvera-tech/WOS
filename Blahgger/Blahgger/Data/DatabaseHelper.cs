using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Blahgger.Data
{
    public static class DatabaseHelper
    {
        private const string DatabaseName = "Blahgger";
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

        /// <summary>
        /// Creates and returns an instance of T from a table retrieved using the input SQL query.
        /// </summary>
        /// <typeparam name="T">The return object type.</typeparam>
        /// <param name="sql">The SQL query.</param>
        /// <param name="constructor">The function that creates an instance of the return object using an SqlDataReader.</param>
        /// <param name="parameters">The SqlParameters to pass into the query.</param>
        /// <returns>An object of type T.</returns>
        public static T Retrieve<T>(string sql, Func<SqlDataReader, T> constructor, params SqlParameter[] parameters)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
            SqlDataReader dataReader;
            T result;

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(sql, connection);
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
                command.Connection.Open();
                dataReader = command.ExecuteReader();
                result = constructor(dataReader);
            }
            return result;
        }

        /// <summary>
        /// Creates and returns an list of objects of type T from a table retrieved using the input SQL query.
        /// </summary>
        /// <typeparam name="T">The return object type.</typeparam>
        /// <param name="sql">The SQL query.</param>
        /// <param name="constructor">The function that creates an instance of the return object using an SqlDataReader.</param>
        /// <param name="parameters">The SqlParameters to pass into the query.</param>
        /// <returns>An object of type T.</returns>
        public static List<T> Retrieve<T>(string sql, Func<SqlDataReader, List<T>> constructor, params SqlParameter[] parameters)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
            SqlDataReader dataReader;
            List<T> result;

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(sql, connection);
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
                command.Connection.Open();
                dataReader = command.ExecuteReader();
                result = constructor(dataReader);
            }
            return result;
        }
    }
}