using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.Interfaces;

namespace Clean.Architecture.UseCases.Persons.Delete;

public class DeletePersonHandler(IDeletePersonService _deletePersonService)
  : ICommandHandler<DeletePersonCommand, Result>
{
  public async Task<Result> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
  {
    // This Approach: Keep Domain Events in the Domain Model / Core project; this becomes a pass-through
    // This is @ardalis's preferred approach
    return await _deletePersonService.DeletePerson(request.PersonId);

    // Another Approach: Do the real work here including dispatching domain events - change the event from internal to public
    // @ardalis prefers using the service above so that **domain** event behavior remains in the **domain model** (core project)
    // var aggregateToDelete = await _repository.GetByIdAsync(request.PersonId);
    // if (aggregateToDelete == null) return Result.NotFound();

    // await _repository.DeleteAsync(aggregateToDelete);
    // var domainEvent = new PersonDeletedEvent(request.PersonId);
    // await _mediator.Publish(domainEvent);
    // return Result.Success();
  }
}
