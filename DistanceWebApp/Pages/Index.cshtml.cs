using DistanceWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DistanceWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        [Range(-90, 90)]
        public double Lat1 { get; set; } = 55.75;

        [BindProperty]
        [Range(-180, 180)]
        public double Lon1 { get; set; } = 37.61;

        [BindProperty]
        [Range(-90, 90)]
        public double Lat2 { get; set; } = 59.93;

        [BindProperty]
        [Range(-180, 180)]
        public double Lon2 { get; set; } = 30.33;

        public double? DistanceKm { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var client = _httpClientFactory.CreateClient("DistanceApi");

            var url = $"api/distance?lat1={Lat1}&lon1={Lon1}&lat2={Lat2}&lon2={Lon2}";
            var result = await client.GetFromJsonAsync<DistanceResponse>(url);

            if (result == null)
            {
                ModelState.AddModelError(string.Empty, "Не удалось получить ответ от службы расчета.");
                return Page();
            }

            DistanceKm = result.DistanceKm;
            return Page();
        }
    }
}