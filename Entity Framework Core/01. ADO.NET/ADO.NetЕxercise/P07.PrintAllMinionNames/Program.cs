using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace P07.PrintAllMinionNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;TrustServerCertificate=true";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            StringBuilder output = new StringBuilder();

            List<string> minionsNames = new List<string>();

            string getAllMinionsNamesQuery =
            @"SELECT Name FROM Minions";

            using SqlCommand getAllMinionsNamesCmd = new SqlCommand(getAllMinionsNamesQuery, sqlConnection);

            using SqlDataReader reader = getAllMinionsNamesCmd.ExecuteReader();
            while (reader.Read())
            {
                minionsNames.Add(reader.GetString(0));
            }

            while (minionsNames.Count > 0)
            {
                output.AppendLine(minionsNames[0]);
                minionsNames.RemoveAt(0);
                minionsNames.Reverse();
            }

            Console.WriteLine(output);
        }
    }
}
