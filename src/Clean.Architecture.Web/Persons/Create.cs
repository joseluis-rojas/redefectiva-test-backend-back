using FastEndpoints;
using Clean.Architecture.Web.Endpoints.PersonEndpoints;
using Clean.Architecture.UseCases.Persons.Create;
using MediatR;

namespace Clean.Architecture.Web.PersonEndpoints;

/// <summary>
/// Create a new Person
/// </summary>
/// <remarks>
/// Creates a new Person given a name.
/// </remarks>
public class Create(IMediator _mediator)
  : Endpoint<CreatePersonRequest, CreatePersonResponse>
{
  public override void Configure()
  {
    Post(CreatePersonRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      // XML Docs are used by default but are overridden by these properties:
      //s.Summary = "Create a new Person.";
      //s.Description = "Create a new Person. A valid name is required.";
      s.ExampleRequest = new CreatePersonRequest { Name = "Person Name", LastName = "Person LastName", Address = "Person Address", Gender = "No binario", PhoneNumber = "1111111111" };
    });
  }

  public override async Task HandleAsync(
    CreatePersonRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new CreatePersonCommand(
      request.Name!,
      request.LastName!, 
      request.Address!, 
      request.Gender!, 
      request.PhoneNumber!));

    if(result.IsSuccess)
    {
      Response = new CreatePersonResponse(result.Value, request.Name!, request.LastName!, request.Address!, request.Gender!, request.PhoneNumber!);
      return;
    }
    // TODO: Handle other cases as necessary
  }
}
