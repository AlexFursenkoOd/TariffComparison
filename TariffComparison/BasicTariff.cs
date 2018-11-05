using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffComparison
{
    class BasicTariff : IElectricityTariff
    {
        private readonly double _baseCostPerMonth;
        private readonly double _consumptionCosts;

        public string Name { get
            {
                return "Basic electricity tariff";
            }
        }

        public BasicTariff(double baseCostPerMonth, double consumptionCosts)
        {
            _baseCostPerMonth = baseCostPerMonth;
            _consumptionCosts = consumptionCosts;
        }

        public BasicTariff() : this(5, 0.22) { }

        public double GetAnnualCosts(double electricity)
        {
            return 12 * _baseCostPerMonth + electricity * _consumptionCosts;
        }
    }
}
