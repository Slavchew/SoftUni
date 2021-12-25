using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05.ChangeTownNamesCasing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;TrustServerCertificate=true";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            StringBuilder output = new StringBuilder();

            string countryName = Console.ReadLine();
            string countryId = GetCountryId(sqlConnection, countryName);

            if (countryId == null)
            {
                Console.WriteLine("No town names were affected.");
                return;
            }

            int rowsAffected = UpdateTownsNamesToUpper(sqlConnection, countryId);

            if (rowsAffected == 0)
            {
                Console.WriteLine("No town names were affected.");
                return;
            }

            output.AppendLine($"{rowsAffected} town names were affected.");

            List<string> townsNames = new List<string>();

            GetAllTownsNames(sqlConnection, countryId, townsNames);

            output.AppendLine($"[{string.Join(", ", townsNames)}]");

            Console.WriteLine(output.ToString().TrimEnd());
        }

        private static void GetAllTownsNames(SqlConnection sqlConnection, string countryId, List<string> townsNames)
        {
            string getTownsNamesQuery =
            @"SELECT Name FROM Towns
            WHERE CountryCode = @countryId";

            using SqlCommand getTownsNamesCmd = new SqlCommand(getTownsNamesQuery, sqlConnection);
            getTownsNamesCmd.Parameters.AddWithValue("@countryId", countryId);
            using SqlDataReader reader = getTownsNamesCmd.ExecuteReader();
            while (reader.Read())
            {
                string name = (string)reader["Name"];
                townsNames.Add(name);
            }
        }

        private static int UpdateTownsNamesToUpper(SqlConnection sqlConnection, string countryId)
        {
            string updateAllTownsNamesQuery =
            @"UPDATE Towns
            SET Name = UPPER(Name)
            WHERE CountryCode = @countryId";

            using SqlCommand updateAllTownsNamesCmd = new SqlCommand(updateAllTownsNamesQuery, sqlConnection);
            updateAllTownsNamesCmd.Parameters.AddWithValue("@countryId", countryId);

            int rowsAffected = updateAllTownsNamesCmd.ExecuteNonQuery();
            return rowsAffected;
        }

        private static string GetCountryId(SqlConnection sqlConnection, string countryName)
        {
            string countryIdQuery =
            @"SELECT Id FROM Countries
            WHERE Name = @countryName";

            using SqlCommand getCountryIdCmd = new SqlCommand(countryIdQuery, sqlConnection);
            getCountryIdCmd.Parameters.AddWithValue("@countryName", countryName);

            string countryId = getCountryIdCmd.ExecuteScalar()?.ToString();
            return countryId;
        }
    }
}
