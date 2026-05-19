using DistanceApi.Models.Requests;

namespace DistanceApi.Services
{
    /// <summary>
    /// Выполняет расчет расстояния между двумя координатами
    /// </summary>
    public class DistanceCalculator : IDistanceCalculator
    {
        private const double EarthRadiusKm = 6371.0;

        /// <summary>
        /// Бизнес-логика
        /// </summary>
        /// <param name="request">DTO-объект запроса</param>
        /// <returns>Расстояние в километрах</returns>
        public double CalculateKm(DistanceRequest request)
        {
            double lat1 = ToRadians(request.Lat1);
            double lon1 = ToRadians(request.Lon1);
            double lat2 = ToRadians(request.Lat2);
            double lon2 = ToRadians(request.Lon2);

            double dLat = lat2 - lat1;
            double dLon = lon2 - lon1;

            double a =
                Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(lat1) * Math.Cos(lat2) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));

            double result = EarthRadiusKm * c;

            return result;
        }

        /// <summary>
        /// Преобразует значение из градусов в радианы 
        /// </summary>
        /// <param name="degress">Градуса</param>
        /// <returns>Радианы</returns>
        private static double ToRadians(double degress)
        {
            return degress * Math.PI / 180.0;
        }
    }
}
