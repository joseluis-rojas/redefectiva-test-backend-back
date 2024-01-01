using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.Architecture.UseCases.Persons.Delete;

public record DeletePersonCommand(int PersonId) : ICommand<Result>;
