using Dapper;
using iRetail.Models;
using Npgsql;
using System.Data;

namespace iRetail.Repository
{
    public class UserDataRepository
    {
        private readonly string connectionString;

        public UserDataRepository()
        {
            connectionString = "Host=localhost;Username=postgres;Password=postgres;Database=iRetail";
        }

        public IDbConnection Connection
        {
            get { return new NpgsqlConnection(connectionString); }
        }

        public IEnumerable<User> GetAll()
        {

            using IDbConnection dbConnection = Connection;
            string sQuery = @"SELECT * FROM Users";
            dbConnection.Open();
            return dbConnection.Query<User>(sQuery);
        }

        public User? GetValidUsername(string username, string password)
        {
            using IDbConnection dbConnection = Connection;
            string sQuery = @"SELECT * FROM Users where Username=@username and Password=@password";
            dbConnection.Open();
            try
            {
                return dbConnection.QuerySingle<User>(sQuery, new { Username = username, Password = password });
            }
            catch
            {
                return null;
            }
        }
    }
}