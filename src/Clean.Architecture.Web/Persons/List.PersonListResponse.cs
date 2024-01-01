using Clean.Architecture.Web.PersonEndpoints;

namespace Clean.Architecture.Web.Endpoints.PersonEndpoints;

public class PersonListResponse
{
  public List<PersonRecord> Persons { get; set; } = [];
}
