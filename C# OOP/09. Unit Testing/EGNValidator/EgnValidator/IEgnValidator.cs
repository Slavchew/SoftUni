using System;

namespace EgnValidator
{
    public interface IEgnValidator
    {
        bool Validate(string egn);

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
        string[] Generate(DateTime birthDate, string city, Gender gender);
    }
}