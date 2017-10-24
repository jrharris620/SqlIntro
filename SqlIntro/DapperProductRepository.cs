using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace SqlIntro
{
    class DapperProductRepository
    {
        private readonly IDbConnection conn;

        public DapperProductRepository(IDbConnection conn)
        {
            this.conn = conn;
        }

        public IEnumerable<Product> GetProducts()
        {
            return conn.Query<Product>("SELECT * FROM product");
        }

        public void DeleteProduct(int ProductId)
        {
            conn.Execute("DELETE FROM product WHERE productId = @id", new { id = ProductId });
        }

        public void UpdateProduct(Product prod)
        {
            conn.Execute("UPDATE product SET name = @name WHERE productId = @id", new { id = prod.ProductId, name = prod.Name });
        }

        public void InsertProduct(Product prod)
        {
            conn.Execute("INSERT into product (Name) values (@name)", new { name = prod.Name });
        }
    }
}
