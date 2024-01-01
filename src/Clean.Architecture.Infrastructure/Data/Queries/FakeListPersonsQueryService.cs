using Clean.Architecture.UseCases.Persons;
using Clean.Architecture.UseCases.Persons.List;

namespace Clean.Architecture.Infrastructure.Data.Queries;

public class FakeListPersonsQueryService : IListPersonsQueryService
{
  public Task<IEnumerable<PersonDTO>> ListAsync()
  {
    List<PersonDTO> result = 
        [new PersonDTO(1, "Fake Person 1", "Fake Last Name 1", "Fake Address 1", "Fake Gender 1", "123456", 1), 
        new PersonDTO(2, "Fake Person 2", "Fake Last Name 2", "Fake Address 2", "Fake Gender 2", "7891011", 1)];

    return Task.FromResult(result.AsEnumerable());
  }
}
