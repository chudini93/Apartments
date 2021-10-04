using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Stretto.ConsoleApp.Models;
using Stretto.ConsoleApp.Services;
using Stretto.ConsoleApp.Services.Interfaces;

namespace Stretto.ConsoleApp
{
    class Program
    {
        private static readonly IApartmentsService _apartmentsService = new ApartmentsService();

        static async Task Main()
        {
            try
            {
                Stopwatch stopWatchParser = new Stopwatch();
                stopWatchParser.Start();
                IList<Apartment> apartments = await _apartmentsService.GetApartmentsAsync();
                stopWatchParser.Stop();
                Console.WriteLine($"Loaded {apartments.Count} apartments in {stopWatchParser.ElapsedMilliseconds} ms");
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
