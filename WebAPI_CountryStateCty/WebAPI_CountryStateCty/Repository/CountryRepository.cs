using WebAPI_CountryStateCty.Data;
using WebAPI_CountryStateCty.Models;
using WebAPI_CountryStateCty.Repository.IRepository;

namespace WebAPI_CountryStateCty.Repository
{
  public class CountryRepository : ICountryRepository
  {
    private readonly ApplicationDbContext _context;
    public CountryRepository(ApplicationDbContext context)
    {
      _context = context;          
    }
    public bool CreateCountry(Country country)
    {
      _context.Countries.Add(country);
      return Save();
    }
    public ICollection<Country> GetCountries()
    {
      return _context.Countries.ToList();
    }

    public Country GetCountry(int countryId)
    {
      return _context.Countries.Find(countryId);
    }

    public bool Save()
    {
      return _context.SaveChanges()==1?true:false;
    }
  }
}
