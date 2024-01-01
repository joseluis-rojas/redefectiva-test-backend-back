using System.ComponentModel.DataAnnotations;

namespace Clean.Architecture.Web.Endpoints.PersonEndpoints;

public class UpdatePersonRequest
{
  public const string Route = "/Persons/{PersonId:int}";


  public static string BuildRoute(int personId) => Route.Replace("{PersonId:int}", personId.ToString());

  public int PersonId { get; set; }

  [Required]
  public int Id { get; set; }
  [Required]
  public string? Name { get; set; }
  [Required]
  public string? LastName { get; set; }
  [Required]
  public string? Address { get; set; }
  [Required]
  public string? Gender { get; set; }
  [Required]
  public string? PhoneNumber { get; set; }
}
