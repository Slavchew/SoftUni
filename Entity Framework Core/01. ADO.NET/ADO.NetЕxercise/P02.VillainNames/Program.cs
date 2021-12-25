using Microsoft.Data.SqlClient;
using System;

namespace P02.VillainNames
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;TrustServerCertificate=true";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            string query =
            @"SELECT v.Name, COUNT(m.ID) AS Count FROM Villains v
            JOIN MinionsVillains mv ON mv.VillainId = v.Id
            JOIN Minions m ON mv.MinionId = m.Id
            GROUP BY v.Name
            HAVING COUNT(m.Id) > 3
            ORDER BY COUNT(m.ID) DESC";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            SqlDataReader reader = sqlCommand.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string villainName = (string)reader["Name"];
                    int minionsCount = (int)reader["Count"];
                    Console.WriteLine($"{villainName} - {minionsCount}");
                }
            }
        }
    }
}
