using System;
using Stretto.ConsoleApp.Services;
using Stretto.ConsoleApp.Services.Interfaces;

namespace Stretto.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IApiApartmentsService apartmentsService = new ApiApartmentsService();
                string csvContent = apartmentsService.GetApartmentsCsv();
                Console.WriteLine($"CSV Loaded:{Environment.NewLine}{csvContent}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
