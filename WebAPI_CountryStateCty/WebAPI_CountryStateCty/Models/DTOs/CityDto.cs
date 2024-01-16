using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_CountryStateCty.Models.DTOs
{
  public class CityDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int StateId { get; set; }
    [ForeignKey("StateId")]
    public State State { get; set; }

  }
}
