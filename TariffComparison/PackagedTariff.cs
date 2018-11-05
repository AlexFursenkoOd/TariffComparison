using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffComparison
{
    class PackagedTariff : IElectricityTariff
    {
        private readonly double _consumptionCosts;
        private readonly double _pachageConsumptionAmount;
        private readonly double _packageCost;

        public string Name
        {
            get
            {
                return "Packaged tariff";
            }
        }

        public PackagedTariff(double packageConsumptionAmount, double packageCost, double consumptionCosts)
        {
            _consumptionCosts = consumptionCosts;
            _pachageConsumptionAmount = packageConsumptionAmount;
            _packageCost = packageCost;
        }

        public PackagedTariff() : this(4000, 800, 0.30) { }

        public double GetAnnualCosts(double electricity)
        {
            if (electricity <= _pachageConsumptionAmount)
            {
                return _packageCost;
            }
            else
            {
                var consumptionOverhead = electricity - _pachageConsumptionAmount;
                return _packageCost + consumptionOverhead * _consumptionCosts;
            }
        }
    }
}
