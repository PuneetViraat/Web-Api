using WebAPI_CountryStateCty.Models;

namespace WebAPI_CountryStateCty.Repository.IRepository
{
  public interface ICountryRepository
  {
    ICollection<Country> GetCountries();
    Country GetCountry(int countryId);
    bool CreateCountry(Country country);
    bool Save();
  }
}
