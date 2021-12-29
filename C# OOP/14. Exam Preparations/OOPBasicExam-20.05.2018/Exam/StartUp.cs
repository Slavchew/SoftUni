using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam
{
    public class StartUp
    {
        //string employeeId, Employee
        private static Dictionary<string, Employee> employees = new Dictionary<string, Employee>();

        //string companyName, Company
        private static Dictionary<string, Company> companies = new Dictionary<string, Company>();


        static void Main(string[] args)
        {
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split(' ').ToArray();

                switch (commandArgs[0])
                {
                    case "CreateEmployee":
                        CreateEmployee(commandArgs.Skip(1).ToArray());
                        break;
                    case "CreateCompany":
                        CreateCompany(commandArgs.Skip(1).ToArray());
                        break;
                    case "PrintCompanyInfo":
                        PrintCompanyInfo(commandArgs.Skip(1).ToArray());
                        break;
                    case "PrintEmployeeInfo":
                        PrintEmployeeInfo(commandArgs.Skip(1).ToArray());
                        break;
                    case "HireEmployee":
                        HireEmployee(commandArgs.Skip(1).ToArray());
                        break;
                    case "FireEmployee":
                        FireEmployee(commandArgs.Skip(1).ToArray());
                        break;
                    case "IncreaseSalaries":
                        IncreaseSalaries(commandArgs.Skip(1).ToArray());
                        break;
                    case "DecreaseSalaries":
                        DecreaseSalaries(commandArgs.Skip(1).ToArray());
                        break;
                    case "GetMostHighPaidEmployee":
                        GetMostHighPaidEmployee(commandArgs.Skip(1).ToArray());
                        break;
                    case "GetTopThreeMostHighPaidEmployees":
                        GetTopThreeMostHighPaidEmployees(commandArgs.Skip(1).ToArray());
                        break;
                    case "CheckEmployeeIsPresent":
                        CheckEmployeeIsPresent(commandArgs.Skip(1).ToArray());
                        break;
                    case "GetAverageEmployeeSalary":
                        GetAverageEmployeeSalary(commandArgs.Skip(1).ToArray());
                        break;
                }
            }
        }

        private static void CreateEmployee(string[] args)
        {
            Employee emp = null;
            try
            {
                if (args.Length == 4)
                {
                    emp = new Employee(args[0], args[1], args[2], int.Parse(args[3]));
                }
                else
                {
                    emp = new Employee(args[0], args[1], args[2], int.Parse(args[3]), double.Parse(args[4]));
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (emp != null)
            {
                employees.Add(emp.Id, emp);
            }
        }

        private static void CreateCompany(string[] args)
        {
            try
            {
                Company company = new Company(args[0], args[1]);
                companies.Add(company.Name, company);

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void PrintCompanyInfo(string[] args)
        {
            Console.WriteLine(companies[args[0]].ToString());
        }

        private static void PrintEmployeeInfo(string[] args)
        {
            Console.WriteLine(employees[args[0]].ToString());
        }

        private static void HireEmployee(string[] args)
        {
            Company company = companies[args[0]];
            Employee emp = employees[args[1]];
            company.HireEmployee(emp);
        }

        private static void FireEmployee(string[] args)
        {
            Company company = companies[args[0]];
            string employeeId = args[1];
            company.FireEmployee(employeeId);
        }

        private static void IncreaseSalaries(string[] args)
        {
            Company company = companies[args[0]];
            company.IncreaseSalaries(double.Parse(args[1]));
        }

        private static void DecreaseSalaries(string[] args)
        {
            Company company = companies[args[0]];
            company.DecreaseSalaries(double.Parse(args[1]));
        }

        private static void GetMostHighPaidEmployee(string[] args)
        {
            Company company = companies[args[0]];
            Employee mostHighPaidEmployee = company.GetMostHighPaidEmployee();

            Console.WriteLine($"The most high paid worker is - {mostHighPaidEmployee}");
        }

        private static void GetTopThreeMostHighPaidEmployees(string[] args)
        {
            Company company = companies[args[0]];
            //Employees should be ordered by salary in descending order!
            List<Employee> threeMostHighPaidEmployee = company.GetTopThreeMostHighPaidEmployees();

            StringBuilder sb = new StringBuilder().Append($"Top three highest paid employees at {company.Name}:\n");
            int place = 1;
            foreach (var emp in threeMostHighPaidEmployee)
            {
                sb.Append($"---#{place++} - {emp}\n");
            }

            Console.WriteLine(sb.ToString().Trim());
        }

        private static void CheckEmployeeIsPresent(string[] args)
        {
            Company company = companies[args[0]];
            string employeeId = args[1];
            bool isPresent = company.CheckEmployeeIsPresent(employeeId);

            Console.WriteLine(isPresent ? $"{employeeId} is present at {company.Name}" : $"{employeeId} is NOT present.");
        }

        private static void GetAverageEmployeeSalary(string[] args)
        {
            Company company = companies[args[0]];

            Console.WriteLine($"The average salary at {company.Name} is: {company.GetAverageEmployeeSalary():F2}");
        }
    }

}
