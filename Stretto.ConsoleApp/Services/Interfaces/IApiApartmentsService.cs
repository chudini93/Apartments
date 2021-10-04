namespace Stretto.ConsoleApp.Services.Interfaces
{
    public interface IApiApartmentsService
    {
        string GetApartmentsCsv();
        string GetTaxesInfo(string cityName);
    }
}
