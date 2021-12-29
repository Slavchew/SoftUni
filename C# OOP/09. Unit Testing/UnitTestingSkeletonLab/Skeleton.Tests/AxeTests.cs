using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    [Test]
    [TestCase(100,100, 100, 100, 99)]
    public void AxeLosesDurabilityAfterAttack(
        int hp, int exp, int attack, int durability, int expectedResult)
    {
        //Arrange
        Dummy dummy = new Dummy(hp, exp);
        Axe axe = new Axe(attack, durability);

        //Act
        axe.Attack(dummy);

        //Assert
        var actualResult = axe.DurabilityPoints;

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void BrokenAxeCantAttack()
    {
        //Arange
        Dummy dummy = new Dummy(10, 10);
        Axe axe = new Axe(20, 0);

        //Act - Assert
        Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
    }
}