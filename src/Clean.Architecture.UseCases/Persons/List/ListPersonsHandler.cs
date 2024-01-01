using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.Architecture.UseCases.Persons.List;

public class ListPersonsHandler(IListPersonsQueryService _query)
  : IQueryHandler<ListPersonsQuery, Result<IEnumerable<PersonDTO>>>
{
  public async Task<Result<IEnumerable<PersonDTO>>> Handle(ListPersonsQuery request, CancellationToken cancellationToken)
  {
    var result = await _query.ListAsync();

    return Result.Success(result);
  }
}
