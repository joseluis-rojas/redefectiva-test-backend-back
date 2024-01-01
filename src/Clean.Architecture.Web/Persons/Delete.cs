using FastEndpoints;
using Ardalis.Result;
using MediatR;
using Clean.Architecture.Web.Endpoints.PersonEndpoints;
using Clean.Architecture.UseCases.Persons.Delete;

namespace Clean.Architecture.Web.PersonEndpoints;

/// <summary>
/// Delete a Person.
/// </summary>
/// <remarks>
/// Delete a Person by providing a valid integer id.
/// </remarks>
public class Delete(IMediator _mediator)
  : Endpoint<DeletePersonRequest>
{
  public override void Configure()
  {
    Delete(DeletePersonRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    DeletePersonRequest request,
    CancellationToken cancellationToken)
  {
    var command = new DeletePersonCommand(request.PersonId);

    var result = await _mediator.Send(command);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      await SendNoContentAsync(cancellationToken);
    };
    // TODO: Handle other issues as needed
  }
}
