using Dapper;
using iRetail.Models;
using Npgsql;
using System.Data;

namespace iRetail.Repository
{
    public class CartRepository
    {
        private readonly string connectionString;

        public CartRepository()
        {
            connectionString = "Host=localhost;Username=postgres;Password=postgres;Database=iRetail";
        }

        public IDbConnection Connection
        {
            get { return new NpgsqlConnection(connectionString); }
        }

        public void AddToCart(Cart prod)
        {
            using IDbConnection dbConnection = Connection;
            string sQuery = @"INSERT INTO cart(username, productid, quantity) VALUES (@Username,@Productid,@Quantity)";
            dbConnection.Open();
            dbConnection.Execute(sQuery, prod);

        }
        public IEnumerable<Cart> GetAllItems(string username)
        {
            using IDbConnection dbConnection = Connection;
            string sQuery = @"Select * from cart where username=@username";
            dbConnection.Open();
            return dbConnection.Query<Cart>(sQuery, new { Username = username });
        }

        public dynamic GetProductName(Guid productid)
        {
            using IDbConnection dbConnection = Connection;
            string sQuery = @"Select productname from products where productid=@productid"; 
            dbConnection.Open();
            return dbConnection.ExecuteScalar(sQuery, new { Productid = productid });
        }

        public void RemoveFromCart(Cart prod)
        {
            using IDbConnection dbConnection = Connection;
            string sQuery = @"DELETE FROM cart WHERE username=@username And productid=@productid";
            dbConnection.Open();
            dbConnection.Execute(sQuery,prod);
        }

        public void UpdateQuantity(Cart prod)
        {
            using IDbConnection dbConnection = Connection;
            string sQuery = @"UPDATE cart SET quantity=@quantity WHERE username=@username and productid=@productid";
            dbConnection.Open();
            dbConnection.Execute(sQuery, prod);
        }
    }
}
