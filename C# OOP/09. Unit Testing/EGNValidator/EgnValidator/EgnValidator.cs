using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EgnValidator
{
    public enum Gender
    {
        Male = 1,
        Female = 2,
    }

    public class EgnValidator : IEgnValidator
    {

        private static readonly DateTime minDate = new DateTime(1800, 01, 01);
        private static readonly DateTime maxDate = new DateTime(2099, 12, 31);
        private int[] egnWeights = { 2, 4, 8, 5, 10, 9, 7, 3, 6 };

        public EgnValidator()
        {
            Regions = new Dictionary<string, IEnumerable<int>>();
            Regions.Add("Благоевград", Enumerable.Range(0, 44));
            Regions.Add("Бургас", Enumerable.Range(44, 50));
            Regions.Add("Варна", Enumerable.Range(94, 46));
            Regions.Add("Велико Търново", Enumerable.Range(140, 30));
            Regions.Add("Видин", Enumerable.Range(170, 14));
            Regions.Add("Враца", Enumerable.Range(184, 34));
            Regions.Add("Габрово", Enumerable.Range(218, 16));
            Regions.Add("Кърджали", Enumerable.Range(234, 48));
            Regions.Add("Кюстендил", Enumerable.Range(282, 20));
            Regions.Add("Ловеч", Enumerable.Range(302, 18));
            Regions.Add("Монтана", Enumerable.Range(320, 22));
            Regions.Add("Пазарджик", Enumerable.Range(342, 36));
            Regions.Add("Перник", Enumerable.Range(378, 18));
            Regions.Add("Плевен", Enumerable.Range(396, 40));
            Regions.Add("Пловдив", Enumerable.Range(436, 66));
            Regions.Add("Разград", Enumerable.Range(502, 26));
            Regions.Add("Русе", Enumerable.Range(528, 28));
            Regions.Add("Силистра", Enumerable.Range(556, 20));
            Regions.Add("Сливен", Enumerable.Range(576, 26));
            Regions.Add("Смолян", Enumerable.Range(602, 22));
            Regions.Add("София - град", Enumerable.Range(624, 98));
            Regions.Add("София - окръг", Enumerable.Range(722, 30));
            Regions.Add("Стара Загора", Enumerable.Range(752, 38));
            Regions.Add("Добрич", Enumerable.Range(790, 32));
            Regions.Add("Търговище", Enumerable.Range(822, 22));
            Regions.Add("Хасково", Enumerable.Range(844, 28));
            Regions.Add("Шумен", Enumerable.Range(872, 32));
            Regions.Add("Ямбол", Enumerable.Range(904, 22));
            Regions.Add("Друг", Enumerable.Range(926, 74));
        }


        private Dictionary<string, IEnumerable<int>> Regions { get; set; }


        /// <summary>
        /// Generate all valid EGN numbers for given criteria.
        /// </summary>
        /// <param name="birthDate">Date of birth.</param>
        /// <param name="city">The city where EGN holders are born in.</param>
        /// <param name="isMale">True for male, false for female</param>
        /// <returns>List of all valid EGN numbers</returns>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidCityException"></exception>
        public string[] Generate(DateTime birthDate, string city, Gender gender)
        {
            if (birthDate.Year < 1800 || birthDate.Year > 2099) // [1800-2099]
            {
                throw new ArgumentOutOfRangeException("birthDate", "Birth date should be greater or equal to 1800");
            }
            if (city == null)
            {
                throw new ArgumentNullException(city);
            }
            if (Regions.ContainsKey(city) == false)
            {
                throw new InvalidCityException(city);
            }
            if (gender != Gender.Male && gender != Gender.Female)
            {
                throw new ArgumentOutOfRangeException("gender", "Gender should be 1 for male,2 for female");
            }

            StringBuilder date = GenerateDateOfBirth(birthDate);
            List<StringBuilder> EgnCollection = new List<StringBuilder>();

            foreach (var regionCode in Regions[city])
            {
                StringBuilder egnToAdd = new StringBuilder(date.ToString());
                if (gender == Gender.Male)
                {
                    if (regionCode % 2 == 0)
                    {
                        egnToAdd.Append($"{ regionCode:d3}");
                        EgnCollection.Add(egnToAdd);
                    }
                }
                else
                {
                    if (regionCode % 2 != 0)
                    {
                        egnToAdd.Append($"{ regionCode:d3}");
                        EgnCollection.Add(egnToAdd);
                    }
                }
            }
            return CalculateControl(EgnCollection).Select(s => s.ToString()).ToArray();
        }



        /// <summary>
        /// Checks the validity of EGN
        /// </summary>
        /// <param name="egn">10 digit EGN to validate</param>
        /// <returns>True for valid,false for invalid</returns>
        public bool Validate(string egn)
        {
            if (egn == null || egn.Length != 10)
            {
                return false;
            }
            else if (long.TryParse(egn, out _) == false)
            {
                return false;
            }

            string[] egnArray = egn.ToCharArray().Select(c => c.ToString()).ToArray();

            if (ValidateDate(egnArray) && ValidateRegion(egnArray) && ValidateControl(egnArray))
            {
                return true;
            }
            return false;
        }


        //Generate date of birth in EGN format from DateTime object.
        private StringBuilder GenerateDateOfBirth(DateTime birthDate)
        {
            StringBuilder egn = new StringBuilder();
            int year = birthDate.Year;
            int month = birthDate.Month;
            int day = birthDate.Day;
            if (year > 1999)
            {
                year -= 2000;
                month += 40;
            }
            else if (year < 1900)
            {
                year -= 1800;
                month += 20;
            }
            else
            {
                year -= 1900;
            }
            return egn.Append($"{year:d2}{month:d2}{day:d2}");
        }


        //Calculates and adds control digits in a List of EGN
        private List<StringBuilder> CalculateControl(List<StringBuilder> egnCollection)
        {
            for (int i = 0; i < egnCollection.Count; i++)
            {
                string egn = egnCollection[i].ToString();
                int controlNum = 0;
                for (int j = 0; j < 9; j++)
                {
                    controlNum += int.Parse(egn[j].ToString()) * egnWeights[j];
                }
                controlNum %= 11;
                if (controlNum == 10)
                {
                    egnCollection[i].Append(0);
                }
                else
                {
                    egnCollection[i].Append(controlNum);
                }
            }
            return egnCollection;
        }


        //Validates the control digit in EGN
        private bool ValidateControl(string[] egnArray)
        {
            int controlNum = int.Parse(egnArray[^1]);
            int result = 0;
            for (int i = 0; i < egnArray.Length - 1; i++)
            {
                result += int.Parse(egnArray[i]) * egnWeights[i];
            }
            result %= 11;
            if (result == 10)
            {
                return controlNum == 0;
            }
            else
            {
                return controlNum == result;
            }
        }



        //Validate region code.
        //Currently the method cannot return false,but can be used to return place of birth from an EGN
        private bool ValidateRegion(string[] egnArray)
        {
            int regionCode = int.Parse($"{egnArray[6]}{egnArray[7]}{egnArray[8]}");
            foreach (var region in Regions)
            {
                if (region.Value.Contains(regionCode))
                {
                    return true;
                }
            }
            return false;
        }


        //Validate date from EGN format
        private bool ValidateDate(string[] egnArray)
        {
            int year = int.Parse($"{egnArray[0]}{egnArray[1]}");
            int month = int.Parse($"{egnArray[2]}{egnArray[3]}");
            int day = int.Parse($"{egnArray[4]}{egnArray[5]}");
            if (month > 0 && month <= 12)
            {
                year += 1900;
            }
            else if (month >= 21 && month <= 32)
            {
                year += 1800;
                month -= 20;
            }
            else if (month >= 41 && month <= 52)
            {
                year += 2000;
                month -= 40;
            }
            else return false;
            try
            {
                DateTime date = new DateTime(year, month, day);
                if (date >= minDate && date <= maxDate)
                {
                    return true;
                }
                return false;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
        }
    }
}
