using NUnit.Framework;

namespace Demo.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void AcountInitializeWithPositiveValue()
        {
            BankAccount acount = new BankAccount(2000m);
            Assert.AreEqual(2000m, acount.Amount);
        }
    }
}