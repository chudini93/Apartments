using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

                DisplayInfoAboutBiggestResidentialApartment(apartments);
                DisplayInfoAboutCheapestApartmentWithMostBedsAndBaths(apartments);
                DisplayInfoAboutMostExpensiveFlatsInEachCity(apartments);
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

        private static void DisplayInfoAboutMostExpensiveFlatsInEachCity(IList<Apartment> apartments)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Dictionary<string, decimal> citiesTaxesDictionary = apartments
                .Select(x => x.City).Distinct()
                .ToDictionary(cityName => cityName, _apartmentsService.GetCityTax);
            
            stopWatch.Stop();
            Console.WriteLine($"Loaded city taxes info in {stopWatch.ElapsedMilliseconds} ms");

            Console.WriteLine("Most expensive apartments in every city:");

            foreach (KeyValuePair<string, decimal> cityTaxesKeyValuePair in citiesTaxesDictionary)
            {
                Apartment mostExpensiveApartmentInCity = apartments
                    .Where(x => x.City == cityTaxesKeyValuePair.Key)
                    .OrderByDescending(x => x.Price)
                    .FirstOrDefault();

                mostExpensiveApartmentInCity?.SavePriceWithTaxes(cityTaxesKeyValuePair.Value);
                DisplayApartmentInfo(mostExpensiveApartmentInCity, cityTaxesKeyValuePair.Key);
            }
        }

        private static void DisplayInfoAboutCheapestApartmentWithMostBedsAndBaths(IList<Apartment> apartments)
        {
            Apartment chepestApartmentsWithMostBedsAndBaths = apartments
                .OrderBy(x => x.Price)
                .ThenByDescending(x => x.NumberOfBeds)
                .ThenByDescending(x => x.NumberOfBaths)
                .FirstOrDefault();

            if (chepestApartmentsWithMostBedsAndBaths != null)
            {
                DisplayApartmentInfo(chepestApartmentsWithMostBedsAndBaths, "Cheapest apartment with most beds and baths");
            }
        }

        private static void DisplayInfoAboutBiggestResidentialApartment(IList<Apartment> apartments)
        {
            Apartment biggestApartment =
                apartments
                    .Where(x => x.Type == "Residential")
                    .OrderByDescending(x => x.SizeInFeet)
                    .FirstOrDefault();

            if (biggestApartment != null)
            {
                DisplayApartmentInfo(biggestApartment, "Biggest Residential apartment");
            }
        }

        static void DisplayApartmentInfo(Apartment apartment, string headline)
        {
            string priceLine = apartment.PriceWithTaxes.HasValue
                ? $"Price incl. tax: ${apartment.PriceWithTaxes}"
                : $"Price: ${apartment.Price}";

            Console.WriteLine($"{headline}:{Environment.NewLine}" +
                              $"\t Beds: {apartment.NumberOfBeds} | Baths: {apartment.NumberOfBaths}{Environment.NewLine}" +
                              $"\t {priceLine}{Environment.NewLine}" +
                              $"\t Street: {apartment.Street} | City: {apartment.City} | State: {apartment.State}{Environment.NewLine}" +
                              $"\t Size: {apartment.SizeInFeet}ft²{Environment.NewLine}");
        }
    }
}
