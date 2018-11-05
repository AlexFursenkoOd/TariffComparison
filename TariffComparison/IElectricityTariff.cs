using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffComparison
{
    public interface IElectricityTariff
    {
        string Name { get; }
        double GetAnnualCosts(double electricity);
    }
}
