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

            SetAllMinionsNameToLowerCase(sqlConnection);

            IncrementMinionsAgeByIdAndMakeNameInTitleCase(sqlConnection, minionsIds);

            PrintAllMinionsNameAndAge(sqlConnection);
        }

        private static void PrintAllMinionsNameAndAge(SqlConnection sqlConnection)
        {
            string getAllMinionsNameAndAgeQuery =
            @"SELECT Name, Age FROM Minions";
            using SqlCommand getAllMinionsNameAndAgeCmd = new SqlCommand(getAllMinionsNameAndAgeQuery, sqlConnection);
            using SqlDataReader reader = getAllMinionsNameAndAgeCmd.ExecuteReader();
            while (reader.Read())
            {
                string minionName = (string)reader["Name"];
                int minionAge = (int)reader["Age"];
                Console.WriteLine($"{minionName} {minionAge}");
            }
        }

        private static void SetAllMinionsNameToLowerCase(SqlConnection sqlConnection)
        {
            string setAllMinionsNameToLowerCaseQuery =
            @"UPDATE Minions
            SET Name = LOWER(Name)";

            using SqlCommand setAllMinionsNameToLowerCaseCmd = new SqlCommand(setAllMinionsNameToLowerCaseQuery, sqlConnection);
            setAllMinionsNameToLowerCaseCmd.ExecuteNonQuery();
        }

        private static void IncrementMinionsAgeByIdAndMakeNameInTitleCase(SqlConnection sqlConnection, int[] minionsIds)
        {
            string incrementMinionsAgeByIdAndMakeNameInTitleCaseQuery =
            @"UPDATE Minions
            SET Age += 1, Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name) - 1)
            WHERE Id = @id";

            using SqlCommand incrementMinionsAgeByIdAndMakeNameInTitleCaseCmd = 
                new SqlCommand(incrementMinionsAgeByIdAndMakeNameInTitleCaseQuery, sqlConnection);

            foreach (var id in minionsIds)
            {
                incrementMinionsAgeByIdAndMakeNameInTitleCaseCmd.Parameters.AddWithValue("@id", id);

                incrementMinionsAgeByIdAndMakeNameInTitleCaseCmd.ExecuteNonQuery();

                incrementMinionsAgeByIdAndMakeNameInTitleCaseCmd.Parameters.RemoveAt(0);
            }
        }
    }
}
