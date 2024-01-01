using Ardalis.Result;

namespace Clean.Architecture.UseCases.Persons.Create;

/// <summary>
/// Create a new Person.
/// </summary>
/// <param name="Name"></param>
public record CreatePersonCommand(string Name, string LastName, string Address, string Gender, string PhoneNumber) : Ardalis.SharedKernel.ICommand<Result<int>>
{

}
