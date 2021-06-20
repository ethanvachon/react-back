using System.ComponentModel.DataAnnotations;

namespace react_back.Models
{
  public class Profile
  {
    [Required]
    public string Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Picture { get; set; }
  }
}