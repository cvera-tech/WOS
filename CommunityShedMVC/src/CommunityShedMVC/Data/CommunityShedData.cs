﻿using CommunityShedMVC.Models;
using CommunityShedMVC.ViewModels;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CommunityShedMVC.Data
{
    using BCrypt.Net;

    /// <summary>
    /// This class handles all interactions between the controller and the database.
    /// </summary>
    public static class CommunityShedData
    {
        /// <summary>
        /// This method queries the database and returns the hashed password
        /// the associated with the input email address.
        /// </summary>
        /// <param name="emailAddress">The email address of the Person row in the database.</param>
        /// <returns>The hashed password of the Person row</returns>
        private static string GetHashedPassword(string emailAddress)
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
        public static Person GetPrincipalPerson(string emailAddress)
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
        /// This method queries the database and returns a list of CommunityRole objects for 
        /// a person with a given user Id.
        /// </summary>
        /// <param name="userId">The Id of the Person row in the database.</param>
        /// <returns>A list of CommunityRole objects for the Person.</returns>
        public static List<CommunityRole> GetCommunityRoles(int userId)
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
        /// This method queries the database and returns a list of Community objects 
        /// for a person with a given user Id.
        /// </summary>
        /// <param name="userId">The Id of the Person row in the database.</param>
        /// <returns>A list of Community objects for the Person.</returns>
        public static List<Community> GetCommunities(int userId)
        {
            string sql = @"
                SELECT
                    C.Id,
                    C.Name,
                    C.IsOpen
                FROM Community C 
                    JOIN CommunityPersonRole CPR ON C.Id = CPR.CommunityId
                WHERE
                    CPR.PersonId=@UserId
				GROUP BY 
                    C.Id, 
                    C.Name, 
                    C.IsOpen";
            List<Community> communities = DatabaseHelper.Retrieve<Community>(sql,
                new SqlParameter("@UserId", userId));
            return communities;
        }

        /// <summary>
        /// This method calls BCrypt.Verify to compare the password in the LoginViewModel
        /// to the corresponding hashed password in the database.
        /// </summary>
        /// <param name="viewModel">The view model with the login credentials.</param>
        /// <returns>True if the passwords match; false otherwise.</returns>
        public static bool AuthenticateUser(LoginViewModel viewModel)
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
        public static void RegisterUser(RegisterViewModel viewModel)
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

        public static void AddCommunity(Community community, int userId)
        {
            string sql = @"
                BEGIN TRAN;

                INSERT INTO Community (Name, IsOpen)
                VALUES (@CommunityName, @IsOpen);

                DECLARE @CommunityId int;
                SET @CommunityId = cast(SCOPE_IDENTITY() AS int);

                INSERT INTO CommunityPersonRole (PersonId, CommunityId, RoleId)
                VALUES 
	                (@UserId, @CommunityId, 1),	-- member
	                (@UserId, @CommunityId, 2), -- approver
	                (@UserId, @CommunityId, 3), -- reviewer
	                (@UserId, @CommunityId, 4); -- enforcer

                COMMIT TRAN;
            ";

            DatabaseHelper.Execute(sql,
                new SqlParameter("@CommunityName", community.Name),
                new SqlParameter("@IsOpen", community.IsOpen),
                new SqlParameter("@UserId", userId));
        }
    }
}