using Stretto.ConsoleApp.Services.Interfaces;

namespace Stretto.ConsoleApp.Services
{
    public class ApiApartmentsService : HttpRequestWrapper, IApiApartmentsService
    {
        private readonly string _baseUrl = "http://net-poland-interview-stretto.us-east-2.elasticbeanstalk.com/api/flats";

        public string GetApartmentsCsv()
        {
            string url = $"{_baseUrl}/csv";
            string output = MakeHttpRequest(url);
            return output;
        }

        public string GetTaxesInfo(string cityName)
        {
            string url = $"{_baseUrl}/taxes?city={cityName}";
            string output = MakeHttpRequest(url);
            return output;
        }
    }
}