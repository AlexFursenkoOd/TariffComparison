using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffComparison
{
    public class PackagedTariff : IElectricityTariff
    {
        private readonly double _consumptionCosts;
        private readonly double _packageConsumptionAmount;
        private readonly double _packageCost;

        public string Name => "Packaged tariff";

        public PackagedTariff(double packageConsumptionAmount, double packageCost, double consumptionCosts)
        {
            _consumptionCosts = consumptionCosts;
            _packageConsumptionAmount = packageConsumptionAmount;
            _packageCost = packageCost;
        }

        public PackagedTariff() : this(4000, 800, 0.30) { }

        public double GetAnnualCosts(double consumption)
        {
            if (consumption < 0)
                throw new ArgumentException("Consumption can't be less then 0");

            if (consumption <= _packageConsumptionAmount)
            {
                return _packageCost;
            }
            else
            {
                var consumptionOverhead = consumption - _packageConsumptionAmount;
                return _packageCost + consumptionOverhead * _consumptionCosts;
            }
        }
    }
}
