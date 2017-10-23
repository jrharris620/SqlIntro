using System;
using System.Data.SqlClient;
using System.Linq;
using MySql.Data.MySqlClient;

namespace SqlIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=localhost;Database=adventureworks;Uid=root;Pwd=jaonna111;"; 
            var repo = new ProductRepository(new MySqlConnection(connectionString));
            foreach (var prod in repo.GetProducts())
            {
                Console.WriteLine
                    (prod.ProductId + " " + prod.Name +   " " + prod.Color);
            }

            var product = new Product
            {
                ProductId = 5,
                Name = "Bike Rack",
                ProductNumber = "BR-1004",
                Color = "Blue",
                SafetyStockLevel = 1000,
                ReorderPoint = 500,
                StandardCost = 500.75,
                ListPrice = 1025.36,
                ModifiedDate = DateTime.Now
            };

            repo.InsertProduct(product);

            var oProduct = new Product()
            {
                ProductId = 1,
                Name = "Road Black, 52"
            };

            repo.UpdateProduct(oProduct);

            repo.DeleteProduct(998);
           
            Console.ReadLine();
        }

       
    }
}
