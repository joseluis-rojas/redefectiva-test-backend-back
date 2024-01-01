using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.Architecture.UseCases.Persons.Get;

public record GetPersonQuery(int PersonId) : IQuery<Result<PersonDTO>>;
