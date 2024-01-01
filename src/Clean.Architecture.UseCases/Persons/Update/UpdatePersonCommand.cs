using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.Architecture.UseCases.Persons.Update;

public record UpdatePersonCommand(
  int PersonId, 
  string NewName, 
  string NewLastName , 
  string NewAddress, 
  string NewGender, 
  string NewPhoneNumber
  ) : ICommand<Result<PersonDTO>>;
