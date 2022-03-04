using System;
using System.Globalization;
using System.Text;

namespace EgnValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("ЕГН Валидатор v 0.1");
            while (true)
            {
                Console.WriteLine("Въведете една от следните опции:\r\n1 - Валидация:\r\n2 - Генерирай:");

                string option = Console.ReadLine();
                EgnValidator validator = new EgnValidator();
                switch (option)
                {
                    case "1":
                        Console.WriteLine("Въведете ЕГН:");
                        string egn = Console.ReadLine().Trim();
                        if (validator.Validate(egn) == false)
                        {
                            Console.WriteLine("ЕГН е НЕВАЛИДЕН");
                        }
                        else
                        {
                            Console.WriteLine("ЕГН е ВАЛИДЕН");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Въведете дата на раждане (Ден/Месец/Година):");
                        string date = Console.ReadLine();
                        DateTime birthDate;
                        DateTimeFormatInfo provider = new DateTimeFormatInfo();
                        provider.ShortDatePattern = "dd/MM/yyyy";
                        if (DateTime.TryParse(date, provider, DateTimeStyles.AssumeLocal, out birthDate) == false)
                        {
                            Console.WriteLine($"Невалидна дата >{date}<");
                            break;
                        }

                        Console.WriteLine("Въведете областен град:");
                        string city = Console.ReadLine();
                        Console.WriteLine("Въведете пол:\r\n1 за мъж\r\n2 за жена");

                        int gender;
                        int.TryParse(Console.ReadLine(), out gender);

                        try
                        {
                            Console.WriteLine(string.Join("\r\n", validator.Generate(birthDate, city, (Gender)gender)));
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            if (ex.Message.Contains("gender"))
                            {
                                Console.WriteLine("Въвели сте невалиден пол");
                            }
                            else if (ex.Message.Contains("birthDate"))
                            {
                                Console.WriteLine("Дата на раждане трябва да е в периода (01.01.1800 <-> 31.12.2099)");
                            }
                        }
                        catch (ArgumentNullException)
                        {

                        }
                        catch (InvalidCityException ex)
                        {
                            Console.WriteLine($"Въвели сте несъществуващ град >{ex.CityName}<");
                        }

                        break;
                    default:
                        Console.WriteLine("Невалидна опция");
                        continue;
                }
            }
        }
    }
}
