using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace P06.RemoveVillain
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;TrustServerCertificate=true";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            StringBuilder output = new StringBuilder();

            int villainId = int.Parse(Console.ReadLine());

            string name;
            GetVillainNameById(sqlConnection, villainId, out name);

            if (name == null)
            {
                Console.WriteLine("No such villain was found.");
                return;
            }

            output.AppendLine($"{name} was deleted.");
            // Need to be here because of reference error when try to delete villain from database
            DeleteAllMinionsAttachedToVillainWithGivenId(sqlConnection, output, villainId);

            DeleteVillainByIdFromDatabase(sqlConnection, output, villainId, name);

            Console.WriteLine(output.ToString().TrimEnd());
        }

        private static void GetVillainNameById(SqlConnection sqlConnection, int villainId, out string name)
        {
            string getVillainNameByIdQuery =
            @"SELECT Name FROM Villains
            WHERE Id = @villainId";
            SqlCommand getVillainNameByIdCmd = new SqlCommand(getVillainNameByIdQuery, sqlConnection);
            getVillainNameByIdCmd.Parameters.AddWithValue("@villainId", villainId);

            name = getVillainNameByIdCmd.ExecuteScalar()?.ToString();
        }

        private static void DeleteAllMinionsAttachedToVillainWithGivenId(SqlConnection sqlConnection, StringBuilder output, int villainId)
        {
            string deleteAllMinionsattachedToVillainQuery =
            @"DELETE FROM MinionsVillains
            WHERE VillainId = @villainId";
            SqlCommand deleteAllMinionsattachedToVillainCmd =
                            new SqlCommand(deleteAllMinionsattachedToVillainQuery, sqlConnection);
            deleteAllMinionsattachedToVillainCmd.Parameters.AddWithValue("@villainId", villainId);

            int minionsReleased = deleteAllMinionsattachedToVillainCmd.ExecuteNonQuery();

            output.AppendLine($"{minionsReleased} minions were released.");
        }

        private static void DeleteVillainByIdFromDatabase(SqlConnection sqlConnection, StringBuilder output, int villainId, string name)
        {
            string deleteVillainByIdQuery =
            @"DELETE FROM Villains
            WHERE Id = @villainId";

            SqlCommand deleteVillainByIdCmd = new SqlCommand(deleteVillainByIdQuery, sqlConnection);
            deleteVillainByIdCmd.Parameters.AddWithValue("@villainId", villainId);

            deleteVillainByIdCmd.ExecuteNonQuery();


        }
    }
}
