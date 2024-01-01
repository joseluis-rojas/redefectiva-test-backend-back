using Clean.Architecture.Web.PersonEndpoints;

namespace Clean.Architecture.Web.Endpoints.PersonEndpoints;

public class UpdatePersonResponse(PersonRecord person)
{
  public PersonRecord Person { get; set; } = person;
}
