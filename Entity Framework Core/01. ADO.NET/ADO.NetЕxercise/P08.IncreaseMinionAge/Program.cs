using Microsoft.Data.SqlClient;
using System;
using System.Linq;

namespace P08.IncreaseMinionAge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;TrustServerCertificate=true";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            int[] minionsIds = Console.ReadLine()
                .Split(" ").Select(int.Parse).ToArray();

            string getMinionNamesQuery =
            @"SELECT Name, Age FROM Minions
            WHERE Id = @id";

            using SqlCommand getMinionNamesCmd = new SqlCommand(getMinionNamesQuery, sqlConnection);

            foreach (var id in minionsIds)
            {
                getMinionNamesCmd.Parameters.AddWithValue("@id", id);

                using SqlDataReader reader = getMinionNamesCmd.ExecuteReader();
                reader.Read();
                string name = (string)reader["Name"];
                int age = (int)reader["Age"];
            }
        }
    }
}
