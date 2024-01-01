namespace Clean.Architecture.Web.Endpoints.PersonEndpoints;

public class CreatePersonResponse(int id, string name, string lastName, string address, string gender, string phoneNumber)
{
  public int Id { get; set; } = id;
  public string Name { get; set; } = name;
  public string LastName { get; set; } = lastName;
  public string Address { get; set; } = address;
  public string Gender { get; set; } = gender;
  public string PhoneNumber { get; set; } = phoneNumber;
}
