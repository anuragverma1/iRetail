using Dapper;
using iRetail.Model;
using Npgsql;
using System.Data;

namespace iRetail.Repository
{
    public class ProductRepository
    {
        private readonly string connectionString;

        public ProductRepository()
        {
            connectionString = "Host=localhost;Username=postgres;Password=postgres;Database=iRetail";
        }

        public IDbConnection Connection
        {
            get { return new NpgsqlConnection(connectionString); }
        }

        public IEnumerable<Product> GetAll()
        {
            using IDbConnection dbConnection = Connection;
            string sQuery = @"SELECT * FROM PRODUCTS";
            dbConnection.Open();
            return dbConnection.Query<Product>(sQuery);
        }

        public IEnumerable<Product> GetByCategory(string category)
        {
            using IDbConnection dbConnection = Connection;
            string sQuery = @"SELECT * FROM Products WHERE CategoryId = @category";
            dbConnection.Open();
            return dbConnection.Query<Product>(sQuery, new { Category = category });
        }

        public IEnumerable<string> GetAllCategories()
        {
            using IDbConnection dbConnection = Connection;
            string sQuery = @"SELECT distinct(categoryid) FROM PRODUCTS";
            dbConnection.Open();
            return dbConnection.Query<string>(sQuery);
        }

        public void AddProduct(Product prod)
        {
            using IDbConnection dbConnection = Connection;
            string sQuery = @"INSERT INTO products(productname, productdesc, categoryid, productquantity, productprice) VALUES (@productname,@productdesc,@categoryid,@productquantity,@productprice)";
            dbConnection.Open();
            dbConnection.Execute(sQuery,prod);
        }
    }
}
