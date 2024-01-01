using FastEndpoints;
using Clean.Architecture.Web.Endpoints.PersonEndpoints;
using Clean.Architecture.UseCases.Persons.Update;
using MediatR;
using Ardalis.Result;
using Clean.Architecture.UseCases.Persons.Get;

namespace Clean.Architecture.Web.PersonEndpoints;

/// <summary>
/// Update an existing Person.
/// </summary>
/// <remarks>
/// Update an existing Person by providing a fully defined replacement set of values.
/// See: https://stackoverflow.com/questions/60761955/rest-update-best-practice-put-collection-id-without-id-in-body-vs-put-collecti
/// </remarks>
public class Update(IMediator _mediator)
  : Endpoint<UpdatePersonRequest, UpdatePersonResponse>
{
  public override void Configure()
  {
    Put(UpdatePersonRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    UpdatePersonRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new UpdatePersonCommand(
      request.Id, 
      request.Name!, 
      request.LastName!, 
      request.Address!, 
      request.Gender!, 
      request.PhoneNumber!));

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    var query = new GetPersonQuery(request.PersonId);

    var queryResult = await _mediator.Send(query);

    if (queryResult.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (queryResult.IsSuccess)
    {
      var dto = queryResult.Value;
      Response = new UpdatePersonResponse(new PersonRecord(
        dto.Id, 
        dto.Name, 
        dto.LastName, 
        dto.Address, 
        dto.Gender, 
        dto.PhoneNumber
        ));
      return;
    }
  }
}
