using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EgnValidator.Tests
{
    [TestFixture]
    public class EgnGeneratorTests
    {
        [Test]
        public void GenerateShouldReturnListOfNumbersForValidInput()
        {
            var generator = new EgnValidator();
            var result = generator.Generate(DateTime.Now, "София - град", Gender.Female);
            Assert.NotNull(result);
            Assert.AreEqual(49, result.Length);
        }

        [Test]
        public void GenerateShouldReturnListOfNumbersForValidInputForVarna()
        {
            var generator = new EgnValidator();
            var result = generator.Generate(new DateTime(2001, 1, 1), "Варна", Gender.Female);
            Assert.NotNull(result);
            Assert.AreEqual(23, result.Length);
        }

        [Test]
        public void GenerateShouldThrowAnExceptionWhenInvalidYearProvided()
        {
            var generator = new EgnValidator();
            Assert.Throws<ArgumentOutOfRangeException>(() => 
                generator.Generate(
                    new DateTime(1760, 1, 1), 
                    "Варна", 
                    Gender.Female));
        }

        [Test]
        public void GenerateShouldGenerateValidEgnsForPazarzhik()
        {
            var generator = new EgnValidator();
            var numbers = generator.Generate(new DateTime(2001, 1, 1), "Пазарджик", Gender.Female);
            foreach (var number in numbers)
            {
                Assert.True(generator.Validate(number));
            }
        }
    }
}
