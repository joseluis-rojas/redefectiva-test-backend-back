using Ardalis.Specification;

namespace Clean.Architecture.Core.PersonAggregate.Specifications;

public class PersonByIdSpec : Specification<Person>
{
  public PersonByIdSpec(int personId)
  {
    Query
        .Where(person => person.Id == personId);
  }
}
