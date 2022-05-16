using Dapper;
using iRetail.Model;
using iRetail.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;

namespace iRetail.Repository
{
    public class SignupRepository
    {
        private readonly string connectionString;

        public SignupRepository()
        {
            connectionString = "Host=localhost;Username=postgres;Password=postgres;Database=iRetail";
        }

        public IDbConnection Connection
        {
            get { return new NpgsqlConnection(connectionString); }
        }

        public IEnumerable<User> GetAllUser()
        {
            using IDbConnection dbConnection = Connection;
            string sQuery = @"select * from Users";
            dbConnection.Open();
            return dbConnection.Query<User>(sQuery);
        }

        public bool RegisterUser(User user)
        {
            if (!AlreadyExists(user))
            {
                user.UserRole = "customer";
                using IDbConnection dbConnection = Connection;
                string sQuery = @"INSERT INTO users(username, password, firstname, lastname, emailaddress, address, telephone, userrole) VALUES (@username,@password,@firstname,@lastname,@emailaddress,@address,@telephone,@userrole)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, user);
                return true;
            }
            return false;
        }

        public bool AlreadyExists(User user)
        {
            using IDbConnection dbConnection = Connection;
            string sQuery = @"select * from Users where username=@username";
            dbConnection.Open();
            try
            {
                dbConnection.QuerySingle(sQuery, user);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
