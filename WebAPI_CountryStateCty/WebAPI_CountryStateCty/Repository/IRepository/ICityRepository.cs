using WebAPI_CountryStateCty.Models;

namespace WebAPI_CountryStateCty.Repository.IRepository
{
  public interface ICityRepository
  {
    ICollection<City> GetCities();
    City GetCity(int cityId);
    bool CreateCity(City city);
    bool Save();
  }
}
