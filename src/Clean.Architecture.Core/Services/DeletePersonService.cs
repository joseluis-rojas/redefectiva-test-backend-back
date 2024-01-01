using Ardalis.Result;
using Clean.Architecture.Core.PersonAggregate;
using Clean.Architecture.Core.PersonAggregate.Events;
using Clean.Architecture.Core.Interfaces;
using Ardalis.SharedKernel;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Clean.Architecture.Core.Services;

public class DeletePersonService(IRepository<Person> _repository,
  IMediator _mediator,
  ILogger<DeletePersonService> _logger) : IDeletePersonService
{
  public async Task<Result> DeletePerson(int personId)
  {
    _logger.LogInformation("Deleting Person {personId}", personId);
    var aggregateToDelete = await _repository.GetByIdAsync(personId);
    if (aggregateToDelete == null) return Result.NotFound();

    await _repository.DeleteAsync(aggregateToDelete);
    var domainEvent = new PersonDeletedEvent(personId);
    await _mediator.Publish(domainEvent);
    return Result.Success();
  }
}
