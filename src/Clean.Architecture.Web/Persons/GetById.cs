using FastEndpoints;
using MediatR;
using Ardalis.Result;
using Clean.Architecture.Web.Endpoints.PersonEndpoints;
using Clean.Architecture.UseCases.Persons.Get;

namespace Clean.Architecture.Web.PersonEndpoints;

/// <summary>
/// Get a Person by integer ID.
/// </summary>
/// <remarks>
/// Takes a positive integer ID and returns a matching Person record.
/// </remarks>
public class GetById(IMediator _mediator)
  : Endpoint<GetPersonByIdRequest, PersonRecord>
{
  public override void Configure()
  {
    Get(GetPersonByIdRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetPersonByIdRequest request,
    CancellationToken cancellationToken)
  {
    var command = new GetPersonQuery(request.PersonId);

    var result = await _mediator.Send(command);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new PersonRecord(result.Value.Id, result.Value.Name, result.Value.LastName ?? "", result.Value.Address ?? "", result.Value.Gender ?? "", result.Value.PhoneNumber ?? "");
    }
  }
}
