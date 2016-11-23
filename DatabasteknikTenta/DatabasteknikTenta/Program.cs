using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatabasteknikTenta.Models;

namespace DatabasteknikTenta
{
    class Program
    {
        static string cns = @"server=(localdb)\MSSQLLocalDB;Database=NORTHWND;Trusted_Connection=Yes";
        
        List<string> categoryList = new List<string>();
        static void Main(string[] args)
        {
            string categoryName;

            Console.WriteLine("Mata in ett kategorinamn: ");

            categoryName = Console.ReadLine();

            Console.WriteLine("=====================================");

            ProductByCategoryName(categoryName);

            
        }

        private static void ProductByCategoryName(string categoryName)
        {
            string queryString =
            @"SELECT Categories.CategoryName, Products.ProductName, Products.UnitPrice, Products.UnitsInStock" + " FROM Categories INNER JOIN Products ON Categories.CategoryID = Products.CategoryID" + " WHERE (Categories.CategoryName = N'" + categoryName + "');";

            using (SqlConnection connection = new SqlConnection(cns))
                {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@categoryName", categoryName);

                
                connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.Write(reader.GetString(1));
                        Console.Write(" " + reader.GetValue(2));
                        Console.WriteLine(" " + reader.GetValue(3));
                        Console.WriteLine("=====================================");
                    }
                    reader.Close();
                
                }
            }
    }
}
