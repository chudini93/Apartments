using System.Collections.Generic;
using System.Threading.Tasks;
using Stretto.ConsoleApp.Models;
using Stretto.ConsoleApp.Services.Base;
using Stretto.ConsoleApp.Services.Interfaces;

namespace Stretto.ConsoleApp.Services
{
    public class ApartmentsCsvParserService : GenericCsvParserService<Apartment>, ICsvParserService
    {
        async Task<IList<Apartment>> ICsvParserService.ParseCsvAsync(string csvContent)
        {
            var output = await ParseCsvAsync(csvContent);
            return output;
        }
    }
}
