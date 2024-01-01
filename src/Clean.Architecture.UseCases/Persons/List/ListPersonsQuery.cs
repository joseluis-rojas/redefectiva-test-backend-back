using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.Architecture.UseCases.Persons.List;

public record ListPersonsQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<PersonDTO>>>;
