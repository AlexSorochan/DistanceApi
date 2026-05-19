using System.ComponentModel.DataAnnotations;

namespace DistanceApi.Models.Requests
{
    /// <summary>
    /// Представляет входные данные для расчета расстояния между двумя точками
    /// </summary>
    public class DistanceRequest
    {
        [Range(-90, 90, ErrorMessage = "Широта должна быть в диапазоне от `-90` до `90`")]
        public double Lat1 { get; set; }

        [Range(-180, 180, ErrorMessage = "Долгота должна быть в диапазоне от `-180` до `180`")]
        public double Lon1 { get; set; }

        [Range(-90, 90, ErrorMessage = "Широта должна быть в диапазоне от `-90` до `90`")]
        public double Lat2 { get; set; }

        [Range(-180, 180, ErrorMessage = "Долгота должна быть в диапазоне от `-180` до `180`")]
        public double Lon2 { get; set; }
    }
}
