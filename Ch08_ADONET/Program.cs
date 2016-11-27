using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Ch08_ADONET
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Northwind;Integrated Security=true;");
            connection.Open();
            Console.WriteLine($"The connection is {connection.State}.");
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
