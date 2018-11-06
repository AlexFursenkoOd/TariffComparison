using NUnit.Framework;
using TariffComparison;

namespace UnitTests
{
    [TestFixture]
    public class PackagedTariff_GetAnnualCosts
    {
        [Test]
        [TestCase(0, 800.0)]
        [TestCase(3500.0, 800.0)]
        [TestCase(6000.0, 1400.0)]
        public void ShouldReturnValidAnnualCosts(double consumption, double expectedCost)
        {
            // Arrange
            var basicTariff = new PackagedTariff();

            // Act
            var annualCost = basicTariff.GetAnnualCosts(consumption);

            // Assert
            Assert.AreEqual(expectedCost, annualCost, "Annual cost calculated incorrectly");
        }
    }
}
