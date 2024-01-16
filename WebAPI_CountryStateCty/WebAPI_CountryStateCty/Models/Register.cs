using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI_CountryStateCty.Models
{
  public class Register
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public GenderType Gender { get; set; }
    
    public int CityId { get; set; }
    public City City { get; set; }
    [NotMapped]
    public int StateId { get; set; }

    public State State { get; set; }
    [NotMapped]
    public int CountryId { get; set; }

    public Country Country { get; set; }
  }
}
