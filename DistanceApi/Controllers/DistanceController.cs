using DistanceApi.Services;
using Microsoft.AspNetCore.Mvc;
using DistanceApi.Models.Requests;
using DistanceApi.Models.Responses;

namespace DistanceApi.Controllers
{
    /// <summary>
    /// HTTP-метод для расчета расстояния между двумя точками
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DistanceController : ControllerBase
    {
        private readonly IDistanceCalculator _distanceCalculator;

        public DistanceController(IDistanceCalculator distanceCalculator)
        {
            _distanceCalculator = distanceCalculator;
        }

        [HttpGet]
        public ActionResult<DistanceResponse> Get([FromQuery] DistanceRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            double distanceKm = _distanceCalculator.CalculateKm(request);

            return Ok(new DistanceResponse
            {
                DistanceKm = Math.Round(distanceKm, 3)
            });
        }
    }
}