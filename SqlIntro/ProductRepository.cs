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
        }

        /// <summary>
        /// Reads all the products from the products table
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetProducts()
        {
            _conn.Open();
            var cmd = _conn.CreateCommand();
            cmd.CommandText = 
                "SELECT * from product ORDER BY ProductId asc"; 
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

            Dispose();
        }

        /// <summary>
        /// Deletes a Product from the database
        /// </summary>
        /// <param name="ProductId"></param>
        public void DeleteProduct(int ProductId)
        {
            _conn.Open();
            var cmd = _conn.CreateCommand();
            cmd.CommandText = "DELETE from product WHERE productId = 998";
            cmd.AddParam("id", ProductId);
            cmd.ExecuteNonQuery();
            Dispose();
        }
        /// <summary>
        /// Updates the Product in the database
        /// </summary>
        /// <param name="prod"></param>
        public void UpdateProduct(Product prod)
        {
            //This is annoying and unnecessarily tedious for large objects.
            //More on this in the future...  Nothing to do here..
            _conn.Open();
            var cmd = _conn.CreateCommand();
            cmd.CommandText = "update product set name = @name where productId = @id";
            cmd.AddParam("@name", prod.Name);
            cmd.AddParam("@id", prod.ProductId);
            cmd.ExecuteNonQuery();
            Dispose();
        }
        /// <summary>
        /// Inserts a new Product into the database
        /// </summary>
        /// <param name="prod"></param>
        public void InsertProduct(Product prod)
        {
            _conn.Open();
            var cmd = _conn.CreateCommand();

            var cText = "INSERT into product (" + string.Join(", ", prod.Params.Keys) + ")";

            var keyValues = prod.Params.Keys.Select(a => "@" + a);
            cText += "VALUES (" + string.Join(", ", keyValues) + ")";

            cmd.CommandText = cText;

            foreach (var keyValuePair in prod.Params)
            {
                cmd.AddParam("@" + keyValuePair.Key, keyValuePair.Value);
            }

            cmd.ExecuteNonQuery();
            Dispose();
        }

        public void Dispose()
        {
            _conn?.Dispose();
        }
    }
}
