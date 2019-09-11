using CommunityShedMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CommunityShedMVC.Data
{
    using BCrypt.Net;
    using ViewModels;

    /// <summary>
    /// This class handles all interactions between the controller and the database.
    /// </summary>
    public class CommunityShedData
    {
        private static CommunityShedData singleton = null;
        private CommunityShedData() { }

        public static CommunityShedData Instance()
        {
            if (singleton == null)
            {
                singleton = new CommunityShedData();
            }
            return singleton;
        }

        public Person GetPerson(string emailAddress)
        {
            string sql = @"
                SELECT HashedPassword
                FROM Person
                WHERE EmailAddress=@EmailAddress
            ";
            Person person = DatabaseHelper.RetrieveSingle<Person>(
                sql,
                new SqlParameter("@EmailAddress", emailAddress));
            return person;
        }

        public bool AuthenticateUser(LoginViewModel viewModel)
        {
            //string hashbrown = BCrypt.HashPassword(viewModel.Password);
            Person person = GetPerson(viewModel.EmailAddress);
            return BCrypt.Verify(viewModel.Password, person.HashedPassword);
        }
    }
}