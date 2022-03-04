using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EgnValidator.Tests
{
    [TestFixture]
    public class EgnValidatorTests
    {
        [Test]
        public void ValidateShouldReturnTrueForValidEgn()
        {
            var validator = new EgnValidator();
            var result = validator.Validate("6101057509");
            Assert.True(result);
        }

        [Test]
        public void ValidateShouldReturnFalseForInvalidEgn()
        {
            var validator = new EgnValidator();
            var result = validator.Validate("0000000000");
            Assert.False(result);
        }

        [Test]
        public void ValidateShouldReturnFalseForInvalidDate()
        {
            var validator = new EgnValidator();
            var result = validator.Validate("6602303411");
            Assert.False(result);
        }

        [Test]
        public void ValidateShouldReturnTrueForValidEgn2()
        {
            var validator = new EgnValidator();
            var result = validator.Validate("9305301149");
            Assert.True(result);
        }

        [Test]
        public void ValidateShouldReturnFalseForInvalidCheckSum()
        {
            var validator = new EgnValidator();
            var result = validator.Validate("9305301144");
            Assert.False(result);
        }

        [Test]
        public void ValidateShouldReturnFalseForNonNumericEgn()
        {
            var validator = new EgnValidator();
            var result = validator.Validate("abcdefghij");
            Assert.False(result);
        }

        [Test]
        public void ValidateShouldReturnFalseForNineDigitsNumber()
        {
            var validator = new EgnValidator();
            var result = validator.Validate("123456789");
            Assert.False(result);
        }
    }
}
