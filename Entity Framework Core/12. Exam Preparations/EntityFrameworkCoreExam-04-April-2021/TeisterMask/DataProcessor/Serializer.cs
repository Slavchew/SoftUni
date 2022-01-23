namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var data = context.Projects.ToList()
                .Where(p => p.Tasks.Any())
                .Select(p => new ProjectXmlExportModel
                {
                    ProjectName = p.Name,
                    HasEndDate = p.DueDate == null ? "No" : "Yes",
                    Tasks = p.Tasks.Select(t => new TaskXmlExportModel
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString(),
                    })
                    .OrderBy(t => t.Name)
                    .ToArray(),
                    TasksCount = p.Tasks.Count()
                })
                .OrderByDescending(p => p.TasksCount)
                .ThenBy(p => p.ProjectName)
                .ToList();

            return XmlConverter.Serialize(data, "Projects");
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var data = context.Employees.ToList()
                .Where(x => x.EmployeesTasks.Any(et => DateTime.Compare(et.Task.OpenDate, date) >= 0))
                .Select(x => new
                {
                    Username = x.Username,
                    Tasks = x.EmployeesTasks.Where(et => DateTime.Compare(et.Task.OpenDate, date) >= 0)
                    .OrderByDescending(et => et.Task.DueDate)
                    .ThenBy(et => et.Task.Name)
                    .Select(et => new
                    {
                        TaskName = et.Task.Name,
                        OpenDate = et.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = et.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = et.Task.LabelType.ToString(),
                        ExecutionType = et.Task.ExecutionType.ToString(),
                    })
                    .ToList()
                })
                .OrderByDescending(x => x.Tasks.Count)
                .ThenBy(x => x.Username)
                .Take(10)
                .ToList();

            return JsonConvert.SerializeObject(data, Formatting.Indented);
        }
    }
}