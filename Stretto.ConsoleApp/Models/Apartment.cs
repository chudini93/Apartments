using System;
using Stretto.ConsoleApp.Attributes;

namespace Stretto.ConsoleApp.Models
{
    public class Apartment
    {
        [CsvName("street")]
        public string Street { get; set; }
        [CsvName("city")]
        public string City { get; set; }
        [CsvName("zip")]
        public string Zip { get; set; }
        [CsvName("state")]
        public string State { get; set; }
        [CsvName("beds")]
        public int NumberOfBeds { get; set; }
        [CsvName("baths")]
        public int NumberOfBaths { get; set; }
        [CsvName("sq__ft")]
        public int SizeInFeet { get; set; }
        [CsvName("type")]
        public string Type { get; set; }
        [CsvName("sale_date")]
        public DateTime SaleDate { get; set; }
        [CsvName("price")]
        public decimal Price { get; set; }
        public decimal? PriceWithTaxes { get; set; }
        [CsvName("latitude")]
        public float Latitude { get; set; }
        [CsvName("longitude")]
        public float Longitude { get; set; }

        /// <summary>
        /// Saves price with taxes in <see cref="PriceWithTaxes"/>.
        /// Formula: (price with tax = price + price * tax)
        /// </summary>
        /// <param name="tax"></param>
        public void SavePriceWithTaxes(decimal tax)
        {
            PriceWithTaxes = Price + Price * tax;
        }
    }
}
