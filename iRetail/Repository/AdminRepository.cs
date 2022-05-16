using Dapper;
using iRetail.Model;
using Npgsql;
using System.Data;

namespace iRetail.Repository
{
    public class AdminRepository
    {
        private readonly string connectionString;

        public AdminRepository()
        {
            connectionString = "Host=localhost;Username=postgres;Password=postgres;Database=iRetail";
        }

        public IDbConnection Connection
        {
            get { return new NpgsqlConnection(connectionString); }
        }

        public void AddProduct(Product prod)
        {
            using IDbConnection dbConnection = Connection;
            string sQuery = @"INSERT INTO products(productname, productdesc, categoryid, productquantity, productprice) VALUES (@productname,@productdesc,@categoryid,@productquantity,@productprice)";
            dbConnection.Open();
            dbConnection.Execute(sQuery, prod);
        }

        public void RemoveProduct(Product prod)
        {
            using IDbConnection dbConnection = Connection;
            string sQuery = @"DELETE FROM products WHERE productid=@productid";
            dbConnection.Open();
            dbConnection.Execute(sQuery, prod);
        }

        public void UpdateQuantity(Product prod)
        {
            using IDbConnection dbConnection = Connection;
            string sQuery = @"Update products set productquantity=@productquantity WHERE productid=@productid";
            dbConnection.Open();
            dbConnection.Execute(sQuery, prod);
        }
    }
}
