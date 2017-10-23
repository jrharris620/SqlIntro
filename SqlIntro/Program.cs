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
                    ("Product Name:" + prod.Name + " " + prod.ProductId + " " + prod.Color);
            }

           
            Console.ReadLine();
        }

       
    }
}
