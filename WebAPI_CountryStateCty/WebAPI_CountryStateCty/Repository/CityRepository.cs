using WebAPI_CountryStateCty.Data;
using WebAPI_CountryStateCty.Models;
using WebAPI_CountryStateCty.Repository.IRepository;

namespace WebAPI_CountryStateCty.Repository
{
  public class CityRepository : ICityRepository
  {
    private readonly ApplicationDbContext _context;
    public CityRepository(ApplicationDbContext context )
    {
      _context = context;          
    }
    public bool CreateCity(City city)
    {
      _context.Cities.Add( city );
      return Save();
    }

    public ICollection<City> GetCities()
    {
      return _context.Cities.ToList();
    }

    public City GetCity(int cityId)
    {
      return _context.Cities.Find(cityId);
    }

    public bool Save()
    {
      return _context.SaveChanges() == 1 ? true : false;
    }
  }
}
