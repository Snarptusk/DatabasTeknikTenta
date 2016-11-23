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

            //Console.WriteLine("Mata in ett kategorinamn: ");
            //categoryName = Console.ReadLine();                            FÖRSTA UPPGIFTEN
            //Console.WriteLine("=====================================");
            //ProductByCategoryName(categoryName);




            //Console.WriteLine("Region - Number of Employees");
            //Console.WriteLine("=====================================");   ANDRA UPPGIFTEN
            //EmployeesPerRegion();

            Console.WriteLine("=====================================");
            CustomersWithNamesLongerThan25Characters();
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

        //private static void SalesByTerritory()
        //{
        //    string queryString =
        //    @"SELECT Categories.CategoryName, Products.ProductName, Products.UnitPrice, Products.UnitsInStock" + " FROM Categories INNER JOIN Products ON Categories.CategoryID = Products.CategoryID" + " WHERE (Categories.CategoryName = N'" + categoryName + "');";

        //    using (SqlConnection connection = new SqlConnection(cns))
        //    {
        //        SqlCommand command = new SqlCommand(queryString, connection);
        //        command.Parameters.AddWithValue("@categoryName", categoryName);


        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            Console.Write(reader.GetString(1));
        //            Console.Write(" " + reader.GetValue(2));
        //            Console.WriteLine(" " + reader.GetValue(3));
        //            Console.WriteLine("=====================================");
        //        }
        //        reader.Close();

        //    }
        //}

        private static void EmployeesPerRegion()
        {
            string queryString =
            @"SELECT Region," + "COUNT(*) AS [Number of employees]" + "FROM employees INNER JOIN EmployeeTerritories ON Employees.EmployeeID = EmployeeTerritories.EmployeeID INNER JOIN Territories ON EmployeeTerritories.TerritoryID = Territories.TerritoryID INNER JOIN Region ON Territories.RegionID = Region.RegionID group by Region";

            using (SqlConnection connection = new SqlConnection(cns))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@categoryName", categoryName);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.Write(reader.GetValue(0));
                    Console.WriteLine(" " + reader.GetValue(1));
                    Console.WriteLine("=====================================");
                }
                reader.Close();

            }
        }

        private static void OrdersPerEmployee()
        {

        }

        private static void CustomersWithNamesLongerThan25Characters()
        {
            using (NORTHWNDContext cx = new NORTHWNDContext())
            {
                //using (NorthwindContext cx = new NorthwindContext())
                //{
                //    foreach (var supplier in cx.Suppliers)
                //    {
                //        if (supplier.Products.Count > 3)
                //        {
                //            Console.WriteLine(supplier.CompanyName);
                //        }
                //    }
                //}

                foreach (var name in cx.Customers)
                {
                    if (name.CompanyName.Length > 25)
                    {
                        Console.WriteLine(name.CompanyName);
                    }
                }
            }
        }

        public static void AddTerritory()
        {
            Console.Write("Input a territory description: ");
            string territory = Console.ReadLine();

            Console.Write("Region ID: ");
            string RegionID = Console.ReadLine();

            SqlConnection cn = new SqlConnection(cns);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "AddTerritory";
            cmd.Parameters.AddWithValue("@TerritoryDescription", territory);
            cmd.Parameters.AddWithValue("@RegionID", RegionID);

            cmd.ExecuteNonQuery();
            cn.Close();

            Console.WriteLine("=======================================");
            Console.WriteLine("Territory added!");
            Console.WriteLine("=======================================");
        }
    }
}
