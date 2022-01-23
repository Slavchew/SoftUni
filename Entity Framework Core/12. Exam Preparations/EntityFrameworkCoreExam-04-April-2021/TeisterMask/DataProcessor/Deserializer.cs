namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder output = new StringBuilder();

            var projects = XmlConverter.Deserializer<ProjectXmlInputModel>(xmlString, "Projects");

            foreach (var xmlProject in projects)
            {
                bool isValidOpenDate = DateTime.TryParseExact(xmlProject.OpenDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime openDate);

                bool isValidDueDate = DateTime.TryParseExact(xmlProject.DueDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dueDate);

                if (!IsValid(xmlProject) || !isValidOpenDate)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if (!isValidDueDate)
                {
                    dueDate = new DateTime(9999, 12, 31);
                }

                List<Task> validTasks = new List<Task>();

                foreach (var xmlTask in xmlProject.Tasks)
                {
                    bool isValidTaskOpenDate = DateTime.TryParseExact(xmlTask.OpenDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskOpenDate);

                    bool isValidTaskDueDate = DateTime.TryParseExact(xmlTask.DueDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskDueDate);

                    bool isValidExecutionType = Enum.TryParse<ExecutionType>(xmlTask.ExecutionType,
                        out ExecutionType executionType);

                    bool isValidLabelType = Enum.TryParse<LabelType>(xmlTask.LabelType,
                        out LabelType labelType);

                    if (!IsValid(xmlTask) || !isValidTaskOpenDate || !isValidTaskDueDate ||
                        !isValidExecutionType || !isValidLabelType ||
                        DateTime.Compare(taskOpenDate, openDate) < 0 || DateTime.Compare(taskDueDate, dueDate) > 0)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task task = new Task
                    {
                        Name = xmlTask.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = executionType,
                        LabelType = labelType,
                    };

                    validTasks.Add(task);
                }

                Project project = new Project
                {
                    Name = xmlProject.Name,
                    OpenDate = openDate,
                    DueDate = isValidDueDate ? (DateTime?)dueDate : null,
                    Tasks = validTasks
                };

                context.Projects.Add(project);
                context.SaveChanges();

                output.AppendLine(String.Format(SuccessfullyImportedProject, 
                    project.Name, 
                    project.Tasks.Count));
            }

            return output.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();

            var employees = JsonConvert.DeserializeObject<IEnumerable<EmployeeInputModel>>(jsonString);

            foreach (var jsonEmployee in employees)
            {
                if (!IsValid(jsonEmployee))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Employee employee = new Employee
                {
                    Username = jsonEmployee.Username,
                    Email = jsonEmployee.Email,
                    Phone = jsonEmployee.Phone,
                };

                // jsonEmployee.Tasks.Any(x => context.Tasks.FirstOrDefault(t => t.Id == x) == null)
                foreach (var jsonTask in jsonEmployee.Tasks.Distinct())
                {
                    if (context.Tasks.FirstOrDefault(x => x.Id == jsonTask) == null)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    employee.EmployeesTasks.Add(new EmployeeTask { TaskId = jsonTask });
                }

                context.Employees.Add(employee);
                context.SaveChanges();
                output.AppendLine(String.Format(SuccessfullyImportedEmployee,
                    employee.Username, employee.EmployeesTasks.Count));
            }

            return output.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}