using FastEndpoints;
using MediatR;
using Clean.Architecture.Web.Endpoints.PersonEndpoints;
using Clean.Architecture.UseCases.Persons.List;

namespace Clean.Architecture.Web.PersonEndpoints;

public class List(IMediator _mediator) : EndpointWithoutRequest<PersonListResponse>
{
  public override void Configure()
  {
    Get("/Persons");
    AllowAnonymous();
  }
  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new ListPersonsQuery(null, null));

    if (result.IsSuccess)
    {
      Response = new PersonListResponse
      {
        Persons = result?.Value?.Select(p => new PersonRecord(
      p.Id,
      p.Name ?? "", 
      p.LastName ?? "",
      p.Address ?? "",
      p.Gender ?? "",
      p.PhoneNumber ?? ""
          )).ToList() ?? new List<PersonRecord>()
      };
    };
  }

}
