using CommunityShedMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CommunityShedMVC.Data
{
    using BCrypt.Net;
    using System.Web.Security;
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

        /// <summary>
        /// This method queries the database and returns the hashed password
        /// the associated with the input email address.
        /// </summary>
        /// <param name="emailAddress">The email address of the Person row in the database.</param>
        /// <returns>The hashed password of the Person row</returns>
        private string GetHashedPassword(string emailAddress)
        {
            string sql = @"
                SELECT HashedPassword
                FROM Person
                WHERE EmailAddress=@EmailAddress
            ";
            Person person = DatabaseHelper.RetrieveSingle<Person>(sql,
                new SqlParameter("@EmailAddress", emailAddress));
            return person.HashedPassword;
        }

        /// <summary>
        /// This method queries the database and returns a Person object with the properties
        /// required to instantiate a CustomPrincipal object.
        /// </summary>
        /// <param name="emailAddress">The email address of the Person row in the database.</param>
        /// <returns>A Person object suitable for instantiating a CustomPrincipal object.</returns>
        public Person GetPrincipalPerson(string emailAddress)
        {
            string sql = @"
                SELECT 
                    Id,
                    FirstName,
                    LastName,
                    EmailAddress
                FROM Person
                WHERE EmailAddress=@EmailAddress
            ";

            Person person = DatabaseHelper.RetrieveSingle<Person>(sql,
                new SqlParameter("@EmailAddress", emailAddress));

            return person;
        }

        /// <summary>
        /// This method queries the database and returns a list of CommunityRoles for 
        /// a person with a given UserId.
        /// </summary>
        /// <param name="userId">The Id of the Person row in the database.</param>
        /// <returns>A list of CommunityRole objects for the Person.</returns>
        public List<CommunityRole> GetCommunityRoles(int userId)
        {
            string sql = @"
                SELECT 
                    CPR.CommunityId,
                    R.Name AS RoleName
                FROM CommunityPersonRole CPR
                    JOIN Role R ON CPR.RoleId = R.Id
                WHERE CPR.PersonId = @UserId
            ";

            List<CommunityRole> roles = DatabaseHelper.Retrieve<CommunityRole>(sql, 
                new SqlParameter("@UserId", userId));

            return roles;
        }

        /// <summary>
        /// This method calls BCrypt.Verify to compare the password in the LoginViewModel
        /// to the corresponding hashed password in the database.
        /// </summary>
        /// <param name="viewModel">The view model with the login credentials.</param>
        /// <returns>True if the passwords match; false otherwise.</returns>
        public bool AuthenticateUser(LoginViewModel viewModel)
        {
            //string hashbrown = BCrypt.HashPassword(viewModel.Password);
            string hashedPassword = GetHashedPassword(viewModel.EmailAddress);
            return BCrypt.Verify(viewModel.Password, hashedPassword);
        }

        /// <summary>
        /// This method inserts a row in the database using form data from the 
        /// input view model.
        /// </summary>
        /// <param name="viewModel">The view model with the form data.</param>
        public void RegisterUser(RegisterViewModel viewModel)
        {
            string sql = @"
                INSERT INTO Person (FirstName, LastName, EmailAddress, HashedPassword)
                VALUES (@FirstName, @LastName, @EmailAddress, @HashedPassword)
            ";
            string hashedPassword = BCrypt.HashPassword(viewModel.Password);

            DatabaseHelper.Insert(sql,
                new SqlParameter("@FirstName", viewModel.FirstName),
                new SqlParameter("@LastName", viewModel.LastName),
                new SqlParameter("@EmailAddress", viewModel.EmailAddress),
                new SqlParameter("@HashedPassword", hashedPassword));
        }
    }
}