using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Ch08_ADONET
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString);
            //SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Northwind;Integrated Security=true;");
            connection.Open();
            Console.WriteLine($"The connection is {connection.State}.");

            Console.WriteLine("Original list of categories: ");
            ListCategories(connection);

            Console.WriteLine("Enter a new category name: ");
            string name = Console.ReadLine();
            if (name.Length >= 15) name = name.Substring(0,15);

            SqlCommand insertCategory = new SqlCommand($"INSERT INTO Categories(CategoryName) VALUES (@NewCategoryName)", connection);
            insertCategory.Parameters.AddWithValue("@NewCategoryName", name);
            int rowsAffected = insertCategory.ExecuteNonQuery();
            Console.WriteLine($"{rowsAffected} rows were inserted.");

            Console.WriteLine("List of categories after inserting: ");
            ListCategories(connection);

            SqlCommand deleteCategory = new SqlCommand($"DELETE FROM Categories WHERE CategoryName = @DeleteCategoryName", connection);
            deleteCategory.Parameters.AddWithValue("@DeleteCategoryName", name);
            rowsAffected = deleteCategory.ExecuteNonQuery();
            Console.WriteLine($"{rowsAffected} rows were deleted.");

            Console.WriteLine("List of categories after deleting: ");
            ListCategories(connection);

            connection.Close();
            Console.WriteLine($"The connection is {connection.State}.");
        }

        private static void ListCategories(SqlConnection conn)
        {
            SqlCommand getCategories = new SqlCommand("SELECT CategoryID, CategoryName FROM Categories", conn);
            SqlDataReader reader = getCategories.ExecuteReader();
            int indexOfID = reader.GetOrdinal("CategoryID");
            int indexOfName = reader.GetOrdinal("CategoryName");
            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetInt32(indexOfID)} : {reader.GetString(indexOfName)}");
            }
            reader.Close();

        }
    }
}
