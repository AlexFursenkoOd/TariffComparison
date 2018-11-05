using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TariffComparison;

namespace UnitTests
{
    [TestClass]
    public class BasicTariff_GetAnnualCosts
    {
        private readonly double _defaultBaseCostPerMonth = 5;
        private readonly double _defaultConsumptionCosts = 0.22;

        [TestMethod]
        public void Consumption3500_Returns830()
        {
            var basicTariff = new BasicTariff();
            var consumption = 3500.0;
            var expectedAnnualCosts = 830.0;

            var annualCosts = basicTariff.GetAnnualCosts(consumption);

            Assert.AreEqual(expectedAnnualCosts, annualCosts, "Annual cost calculated incorrectly");
        }

        [TestMethod]
        public void Consumption6000_Returns1380()
        {
            var basicTariff = new BasicTariff();
            var consumption = 6000.0;
            var expectedAnnualCosts = 1380.0;

            var annualCosts = basicTariff.GetAnnualCosts(consumption);

            Assert.AreEqual(expectedAnnualCosts, annualCosts, "Annual cost calculated incorrectly");
        }

        [TestMethod]
        public void Consumption0_Returns60()
        {
            var basicTariff = new BasicTariff();
            var consumption = 0;
            var expectedAnnualCosts = 60;

            var annualCosts = basicTariff.GetAnnualCosts(consumption);

            Assert.AreEqual(expectedAnnualCosts, annualCosts, "Annual cost calculated incorrectly");
        }

        [TestMethod]
        public void BaseCostPerMonth15Consumption0_Returns180()
        {
            var baseCostPerMonth = 15;
            var consumption = 0;
            var expectedAnnualCosts = 180;
            var basicTariff = new BasicTariff(baseCostPerMonth, _defaultConsumptionCosts);

            var annualCosts = basicTariff.GetAnnualCosts(consumption);

            Assert.AreEqual(expectedAnnualCosts, annualCosts, "Annual cost calculated incorrectly");
        }

        [TestMethod]
        public void ConsumptionCosts01Consumption500_Returns180()
        {
            var consumptionCosts = 0.1; 
            var consumption = 500;
            var expectedAnnualCosts = 110;
            var basicTariff = new BasicTariff(_defaultBaseCostPerMonth, consumptionCosts);

            var annualCosts = basicTariff.GetAnnualCosts(consumption);

            Assert.AreEqual(expectedAnnualCosts, annualCosts, "Annual cost calculated incorrectly");
        }
    }
}
