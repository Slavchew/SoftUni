using System;
using Microsoft.Data.SqlClient;

namespace Ado.NetDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("FirstName: ");
            string firstName = Console.ReadLine();
            Console.Write("LastName: ");
            string lastName = Console.ReadLine();


            string connectionString = @"Server=.;Database=SoftUni;Integrated Security=true;TrustServerCertificate=true";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                //string command = "SELECT COUNT(*) FROM Employees WHERE FirstName = '@FirstName' AND LastName = '@LastName'";
                SqlCommand sqlCommand = new SqlCommand(
                        "SELECT COUNT(*) FROM Employees WHERE FirstName = @FirstName AND LastName = @LastName",
                        sqlConnection);
                sqlCommand.Parameters.AddWithValue("@FirstName", firstName);
                sqlCommand.Parameters.AddWithValue("@LastName", lastName);

                int usersCount = (int)sqlCommand.ExecuteScalar();
                if (usersCount > 0)
                {
                    Console.WriteLine("Welcome to our secret data.");
                }
                else
                {
                    Console.WriteLine("No access");
                }

                //PrintQueryInformation(sqlCommand);
                //string updateCommand = "UPDATE Employees SET Salary = Salary * 1.10";
                //SqlCommand updateSalaryCommand = new SqlCommand(updateCommand, sqlConnection);
                //int updatedRows = updateSalaryCommand.ExecuteNonQuery();
                //Console.WriteLine();
                //Console.WriteLine($"Salary updated for {updatedRows} for employee(s)");
                //Console.WriteLine();
                //PrintQueryInformation(sqlCommand);
            }
        }

        private static void PrintQueryInformation(SqlCommand sqlCommand)
        {
            SqlDataReader reader = sqlCommand.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    decimal salary = (decimal)reader["Salary"];
                    Console.WriteLine($"{firstName} {lastName} => {salary}");
                }
            }
        }
    }
}
