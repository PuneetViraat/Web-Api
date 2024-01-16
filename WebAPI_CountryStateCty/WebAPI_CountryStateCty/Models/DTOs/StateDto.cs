using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_CountryStateCty.Models.DTOs
{
  public class StateDto
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public int CountryId { get; set; }
    [ForeignKey("CountryId")]
    public Country Country { get; set; }
  }
}
