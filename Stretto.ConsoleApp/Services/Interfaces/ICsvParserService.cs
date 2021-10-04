using System.Collections.Generic;
using System.Threading.Tasks;
using Stretto.ConsoleApp.Models;

namespace Stretto.ConsoleApp.Services.Interfaces
{
    public interface ICsvParserService
    {
        Task<IList<Apartment>> ParseCsvAsync(string csvContent);
    }
}