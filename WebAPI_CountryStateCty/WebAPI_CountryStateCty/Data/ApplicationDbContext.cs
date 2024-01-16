using Microsoft.EntityFrameworkCore;
using WebAPI_CountryStateCty.Models;

namespace WebAPI_CountryStateCty.Data
{
  public class ApplicationDbContext:DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      :base(options)
    {
          
    }
    public DbSet<Country> Countries { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Register> Registers { get; set; }
  }
}
