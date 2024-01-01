using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.PersonAggregate;

namespace Clean.Architecture.UseCases.Persons.Update;

public class UpdatePersonHandler(IRepository<Person> _repository)
  : ICommandHandler<UpdatePersonCommand, Result<PersonDTO>>
{
  public async Task<Result<PersonDTO>> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
  {
    var existingPerson = await _repository.GetByIdAsync(request.PersonId, cancellationToken);
    if (existingPerson == null)
    {
      return Result.NotFound();
    }

      existingPerson.UpdateName(request.NewName!);
  
      existingPerson.UpdateLastName(request.NewLastName!);

       existingPerson.UpdateAddress(request.NewAddress!);

      existingPerson.UpdateGender(request.NewGender!);

      existingPerson.UpdatePhoneNumber(request.NewPhoneNumber!);

    await _repository.UpdateAsync(existingPerson, cancellationToken);

    return Result.Success(new PersonDTO(
      existingPerson.Id, 
      existingPerson.Name, 
      existingPerson.LastName,
      existingPerson.Address, 
      existingPerson.Gender, 
      existingPerson.PhoneNumber,
      existingPerson.Status
      ));
  }
}
