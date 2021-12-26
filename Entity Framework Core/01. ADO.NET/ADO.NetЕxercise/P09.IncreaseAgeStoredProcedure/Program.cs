using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace P09.IncreaseAgeStoredProcedure
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;TrustServerCertificate=true";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            int minionId = int.Parse(Console.ReadLine());

            ExecuteStoredProcedureThatIncrementMinionAge(sqlConnection, minionId);
            PrintMinionNameAndAge(sqlConnection, minionId);
        }

        private static void PrintMinionNameAndAge(SqlConnection sqlConnection, int minionId)
        {
            string getMinionInfoQuery =
            @"SELECT Name, Age FROM Minions
            WHERE Id = @minionID";
            SqlCommand getMinionInfoCmd = new SqlCommand(getMinionInfoQuery, sqlConnection);
            getMinionInfoCmd.Parameters.AddWithValue("@minionID", minionId);
            SqlDataReader reader = getMinionInfoCmd.ExecuteReader();
            reader.Read();
            string minionName = (string)reader["Name"];
            int minionAge = (int)reader["Age"];

            Console.WriteLine($"{minionName} – {minionAge} years old");
        }

        private static void ExecuteStoredProcedureThatIncrementMinionAge(SqlConnection sqlConnection, int minionId)
        {
            string storedProcName = "usp_GetOlder";

            using SqlCommand increaseAgeStoredProcedureCmd = new SqlCommand(storedProcName, sqlConnection);
            increaseAgeStoredProcedureCmd.CommandType = CommandType.StoredProcedure;
            increaseAgeStoredProcedureCmd.Parameters.AddWithValue("@minionID", minionId);

            increaseAgeStoredProcedureCmd.ExecuteNonQuery();
        }
    }
}
