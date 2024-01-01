using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clean.Architecture.Web.Endpoints.PersonEndpoints;

public class CreatePersonRequest
{
  public const string Route = "/Persons";

  [Required]
  public string Name { get; set; } = string.Empty;
  [Required]
  public string LastName { get; set; } = string.Empty;
  [Required]
  public string Address { get; set; } = string.Empty;
  [Required]
  public string Gender { get; set; } = string.Empty;
  [Required]
  public string PhoneNumber { get; set; } = string.Empty;
}

