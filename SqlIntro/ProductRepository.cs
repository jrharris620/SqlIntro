using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SqlIntro
{
    public class ProductRepository : IDisposable
    {
        private readonly IDbConnection _conn;

        public ProductRepository(IDbConnection conn)
        {
            _conn = conn;
            _conn.Open();
        }

        /// <summary>
        /// Reads all the products from the products table
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetProducts()
        {

            var cmd = _conn.CreateCommand();
            cmd.CommandText = 
                "SELECT Name, ProductId, Color from product WHERE ProductId = 2"; 
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                yield return new Product
                {
                    Name = dr["Name"].ToString(),
                    ProductId = (int)dr["ProductId"],
                    Color = dr["Color"].ToString()
                };
            }

        }

        /// <summary>
        /// Deletes a Product from the database
        /// </summary>
        /// <param name="ProductId"></param>
        public void DeleteProduct(int ProductId)
        {
            var cmd = _conn.CreateCommand();
            cmd.CommandText = "DELETE from products WHERE productId = 2";
            cmd.AddParam("id", ProductId);
            cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// Updates the Product in the database
        /// </summary>
        /// <param name="prod"></param>
        public void UpdateProduct(Product prod)
        {
            //This is annoying and unnecessarily tedious for large objects.
            //More on this in the future...  Nothing to do here..

            var cmd = _conn.CreateCommand();
            cmd.CommandText = "update product set color = 'red'  where productId = 2";
            cmd.AddParam("name", prod.Name);
            cmd.AddParam("id", prod.ProductId);
            cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// Inserts a new Product into the database
        /// </summary>
        /// <param name="prod"></param>
        public void InsertProduct(Product prod)
        {

            var cmd = _conn.CreateCommand();
            cmd.CommandText = "INSERT into product (name) values(@name)";
            cmd.AddParam("name", prod.Name);
            cmd.ExecuteNonQuery();
        }

        public void Dispose()
        {
            _conn?.Dispose();
        }
    }
}
