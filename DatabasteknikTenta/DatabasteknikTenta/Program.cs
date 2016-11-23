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

        //Category category = new Category();
        
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

                //try
                //{
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
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}
                //Console.ReadLine();
            }

                //using (var db = new NORTHWNDContext())
                //{
                //    List<string> productList = new List<string>();

                //    var products = (from c in db.Categories
                //                    where db.Categories = categoryName
                //                    orderby p.ProductID
                //                    select p).ToArray();

                //    foreach(var item in products)
                //    {
                //        if (item.ProductName.Contains(categoryName))
                //            Console.WriteLine(products);
                //    }

                //    Category category = new Category();

                //category.ProductName = db.Products

                //foreach (var item in products)
                //{
                //    productList.Add(item);
                //}

                //Category category = new DatabasteknikTenta.Program.Category();

                //category.ProductName = 
                //}

                //using (var db = new )
                //{

                //}

                //SqlConnection cn = new SqlConnection(cns);
                //cn.Open();
                //SqlCommand cmd = cn.CreateCommand();
                //SqlDataReader dr = cmd.ExecuteReader();

                //while(dr.Read())
                //{

                //}

                //SqlCommand cmd = cn.CreateCommand();
                //cn.Close();
            }

        public class Category
        {
            public string ProductName { get; set; }
            public int UnitPrice { get; set; }
            public int UnitsInStock { get; set; }
        }
    }
}
