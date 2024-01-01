using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.PersonAggregate;

namespace Clean.Architecture.UseCases.Persons.Create;

public class CreatePersonHandler(IRepository<Person> _repository)
  : ICommandHandler<CreatePersonCommand, Result<int>>
{
  public async Task<Result<int>> Handle(CreatePersonCommand request,
    CancellationToken cancellationToken)
  {
    var newPerson = new Person(request.Name, request.LastName, request.Address, request.Gender, request.PhoneNumber);
 
    var createdItem = await _repository.AddAsync(newPerson, cancellationToken);

    return createdItem.Id;
  }
}
