using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TariffComparison;

namespace UnitTests
{
    [TestClass]
    public class PackagedTariff_GetAnnualCosts
    {
        private readonly double _defaultConsumptionCosts = 800;
        private readonly double _defaultPackageConsumptionAmount = 4000;
        private readonly double _defaultPackageCost = 0.3;

        [TestMethod]
        public void Consumption3500_Returns800()
        {
            var basicTariff = new PackagedTariff();
            var consumption = 3500.0;
            var expectedAnnualCosts = 800.0;

            var annualCosts = basicTariff.GetAnnualCosts(consumption);

            Assert.AreEqual(expectedAnnualCosts, annualCosts, "Annual cost calculated incorrectly");
        }

        [TestMethod]
        public void Consumption6000_Returns1480()
        {
            var basicTariff = new PackagedTariff();
            var consumption = 6000.0;
            var expectedAnnualCosts = 1400.0;

            var annualCosts = basicTariff.GetAnnualCosts(consumption);

            Assert.AreEqual(expectedAnnualCosts, annualCosts, "Annual cost calculated incorrectly");
        }

        [TestMethod]
        public void Consumption0_Returns800()
        {
            var basicTariff = new PackagedTariff();
            var consumption = 0;
            var expectedAnnualCosts = 800;

            var annualCosts = basicTariff.GetAnnualCosts(consumption);

            Assert.AreEqual(expectedAnnualCosts, annualCosts, "Annual cost calculated incorrectly");
        }

        [TestMethod]
        public void PackageConsumptionAmount6000Consumption5900_Returns800()
        {
            var basicTariff = new PackagedTariff(6000.0, _defaultConsumptionCosts, _defaultPackageCost);
            var consumption = 5900;
            var expectedAnnualCosts = 800;

            var annualCosts = basicTariff.GetAnnualCosts(consumption);

            Assert.AreEqual(expectedAnnualCosts, annualCosts, "Annual cost calculated incorrectly");
        }

        [TestMethod]
        public void PackageCost05Consumption5900_Returns1750()
        {
            var basicTariff = new PackagedTariff(_defaultPackageConsumptionAmount, _defaultConsumptionCosts, 0.5);
            var consumption = 5900;
            var expectedAnnualCosts = 1750;

            var annualCosts = basicTariff.GetAnnualCosts(consumption);

            Assert.AreEqual(expectedAnnualCosts, annualCosts, "Annual cost calculated incorrectly");
        }

        [TestMethod]
        public void PackageConsumptionCost700Consumption300_Returns700()
        {
            var basicTariff = new PackagedTariff(_defaultPackageConsumptionAmount, 700, _defaultPackageCost);
            var consumption = 300;
            var expectedAnnualCosts = 700;

            var annualCosts = basicTariff.GetAnnualCosts(consumption);

            Assert.AreEqual(expectedAnnualCosts, annualCosts, "Annual cost calculated incorrectly");
        }
    }
}
