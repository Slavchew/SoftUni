using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentClasses
{
    class StudentClasses
    {
        static void Main(string[] args)
        {
            var classes = new Dictionary<string, List<string>>();

            var input = Console.ReadLine().Split(" ").ToList();
            while (input[0] != "End")
            {
                var command = input[0];
                if (command == "Add")
                {
                    var studentName = input[1];
                    var className = input[2];

                    if (classes.ContainsKey(className))
                    {
                        classes[className].Add(studentName);
                    }
                    else
                    {
                        classes[className] = new List<string>();
                        classes[className].Add(studentName);
                    }

                }
                else if (command == "Transfer")
                {
                    var studentName = input[1];
                    var fromClass = input[3];
                    var toClass = input[5];

                    classes[fromClass].Remove(studentName);

                    if (classes.ContainsKey(toClass))
                    {
                        classes[toClass].Add(studentName);
                    }
                    else
                    {
                        classes[toClass] = new List<string>();
                        classes[toClass].Add(studentName);
                    }

                    if (classes[fromClass].Count == 0)
                    {
                        classes.Remove(fromClass);
                    }
                }
                else if (command == "Merge")
                {
                    var firstClass = input[1];
                    var secondClass = input[2];

                    var firstClassStudent = classes[firstClass];

                    classes[secondClass].AddRange(firstClassStudent);

                    classes.Remove(firstClass);
                }

                input = Console.ReadLine().Split(" ").ToList();
            }

            var sortedClasses = classes.OrderByDescending(x => x.Value.Count).ThenBy(a => a.Key);

            foreach (var paralelka in sortedClasses)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Class name – {paralelka.Key}");
                foreach (var student in paralelka.Value)
                {
                    sb.AppendLine($"###{student}");
                }

                Console.WriteLine(sb.ToString().Trim());
            }
        }
    }
}
