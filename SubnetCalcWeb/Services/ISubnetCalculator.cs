using SubnetCalcWeb.Models;

namespace SubnetCalcWeb.Services
{
    public interface ISubnetCalculator
    {
        SubnetResult Calculate(string ipAddress, int prefixLength);
    }
}
