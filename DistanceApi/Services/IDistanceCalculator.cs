using DistanceApi.Models.Requests;

namespace DistanceApi.Services
{
    public interface IDistanceCalculator
    {
        double CalculateKm(DistanceRequest request);
    }
}
