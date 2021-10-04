using System.Collections.Generic;
using System.Threading.Tasks;
using Stretto.ConsoleApp.Models;

namespace Stretto.ConsoleApp.Services.Interfaces
{
    public interface IApartmentsService
    {
        Task<IList<Apartment>> GetApartmentsAsync();
        decimal GetCityTax(string cityName);
    }
}