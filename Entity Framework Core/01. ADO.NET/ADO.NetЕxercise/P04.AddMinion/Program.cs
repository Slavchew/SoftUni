using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Text;

namespace P04.AddMinion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;TrustServerCertificate=true";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            string[] minionsInput = Console.ReadLine()
                .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string[] minionsInfo = minionsInput[1]
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] villainsInput = Console.ReadLine()
                .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] villainsInfo = villainsInput[1]
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();


            string result = AddMinionToDatabase(sqlConnection, minionsInfo, villainsInfo);

            Console.WriteLine(result);
        }

        private static string AddMinionToDatabase(SqlConnection sqlConnection, string[] minionsInfo, string[] villainsInfo)
        {
            StringBuilder output = new StringBuilder();
            string minionName = minionsInfo[0];
            int minionsAge = int.Parse(minionsInfo[1]);
            string minionTown = minionsInfo[2];
            //string townCountry = minionsInfo[3]; 

            string villainName = villainsInfo[0];

            string townId = EnsureTownExists(sqlConnection, minionTown, output);

            string villainID = EnsureVillainExists(sqlConnection, villainName, output);

            InsertMinionToDatabase(sqlConnection, minionName, minionsAge, townId);

            int minionId = GetMinionId(sqlConnection, minionName);
            InsertMinionToVillain(sqlConnection, output, minionName, villainName, villainID, minionId);

            return output.ToString().TrimEnd();

        }

        private static void InsertMinionToVillain(SqlConnection sqlConnection, StringBuilder output, string minionName, string villainName, string villainID, int minionId)
        {
            string insertMinionToVillainQuery =
            @"INSERT INTO MinionsVillains(MinionId, VillainId)
            VALUES
            (@minionId, @villainId)";
            SqlCommand insertMinionToVillainCmd = new SqlCommand(insertMinionToVillainQuery, sqlConnection);
            insertMinionToVillainCmd.Parameters.AddWithValue("@minionId", minionId);
            insertMinionToVillainCmd.Parameters.AddWithValue("@villainId", villainID);

            insertMinionToVillainCmd.ExecuteNonQuery();

            output.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");
        }

        private static int GetMinionId(SqlConnection sqlConnection, string minionName)
        {
            string getMinionIdQuery =
            @"SELECT Id FROM Minions
            WHERE Name = @minionName";
            SqlCommand getMinionIdCmd = new SqlCommand(getMinionIdQuery, sqlConnection);
            getMinionIdCmd.Parameters.AddWithValue("@minionName", minionName);

            int minionId = (int)getMinionIdCmd.ExecuteScalar();
            return minionId;
        }

        private static void InsertMinionToDatabase(SqlConnection sqlConnection, string minionName, int minionsAge, string townId)
        {
            string insertMinionQuery =
            @"INSERT INTO Minions(Name, Age, TownId)
            VALUES
            (@minionName, @minionAge, @townId)";

            SqlCommand insertMinionCmd = new SqlCommand(insertMinionQuery, sqlConnection);
            insertMinionCmd.Parameters.AddRange(new[]
            {
                new SqlParameter("@minionName", minionName),
                new SqlParameter("@minionAge", minionsAge),
                new SqlParameter("@townId", townId)
            });

            insertMinionCmd.ExecuteNonQuery();
        }

        private static string EnsureVillainExists(SqlConnection sqlConnection, string villainName, StringBuilder output)
        {
            string getVillainIdQuery =
            @"SELECT Id FROM Villains
            WHERE Name = @villainName";

            using SqlCommand getVillainIdCmd = new SqlCommand(getVillainIdQuery, sqlConnection);
            getVillainIdCmd.Parameters.AddWithValue("@villainName", villainName);

            string villainId = getVillainIdCmd.ExecuteScalar()?.ToString();

            if (villainId == null)
            {

                string getFactorQuery =
                @"SELECT Id FROM EvilnessFactors
                WHERE Name = 'Evil'";

                using SqlCommand getFactorCmd = new SqlCommand(getFactorQuery, sqlConnection);
                int evilFactorId = (int)getFactorCmd.ExecuteScalar();

                string insertVillainQuery =
                @"INSERT INTO Villains(Name, EvilnessFactorId)
                VALUES
                (@villainName, @evilFactorId)";

                using SqlCommand insertVillainCmd = new SqlCommand(insertVillainQuery, sqlConnection);
                insertVillainCmd.Parameters.AddWithValue("@villainName", villainName);
                insertVillainCmd.Parameters.AddWithValue("@evilFactorId", evilFactorId);

                insertVillainCmd.ExecuteNonQuery();

                villainId = getVillainIdCmd.ExecuteScalar().ToString();

                output.AppendLine($"Villain {villainName} was added to the database.");
            }

            return villainId;
        }

        private static string EnsureTownExists(SqlConnection sqlConnection, string minionTown, StringBuilder output)
        {
            string getTownIdQuery =
            @"SELECT Id FROM Towns
            WHERE Name = @townName";

            using SqlCommand getTownIdCmd = new SqlCommand(getTownIdQuery, sqlConnection);
            getTownIdCmd.Parameters.AddWithValue("@townName", minionTown);

            string townId = getTownIdCmd.ExecuteScalar()?.ToString();

            if (townId == null)
            {
                string insertTownQuery =
                @"INSERT INTO Towns(Name, CountryCode)
                VALUES
                (@townName, 1)";

                using SqlCommand insertTownCmd = new SqlCommand(@insertTownQuery, sqlConnection);
                insertTownCmd.Parameters.AddWithValue("@townName", minionTown);

                insertTownCmd.ExecuteNonQuery();

                townId = getTownIdCmd.ExecuteScalar().ToString();

                output.AppendLine($"Town {minionTown} was added to the database.");
            }

            return townId;
        }
    }
}
