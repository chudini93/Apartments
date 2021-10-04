using System.Collections.Generic;
using System.Threading.Tasks;
using Stretto.ConsoleApp.Models;
using Stretto.ConsoleApp.Services.Interfaces;

namespace Stretto.ConsoleApp.Services
{
    public class ApartmentsService : IApartmentsService
    {
        // TODO: Dependency injection and IoC container.
        private readonly IApiApartmentsService _apiService;
        private readonly ICsvParserService _csvParserService;

        public ApartmentsService()
        {
            _apiService = new ApiApartmentsService();
            _csvParserService = new ApartmentsCsvParserService();
        }

        public async Task<IList<Apartment>> GetApartmentsAsync()
        {
            string csvContent = _apiService.GetApartmentsCsv();

            IList<Apartment> output = await _csvParserService.ParseCsvAsync(csvContent);
            return output;
        }

        public decimal GetCityTax(string cityName)
        {
            string taxesResponse = _apiService.GetTaxesInfo(cityName);
            if (string.IsNullOrWhiteSpace(taxesResponse))
                // TODO: Rewrite the output to something what makes more sense.
                return -1;

            decimal output = decimal.Parse(taxesResponse);
            return output;
        }
    }
}