using Clean.Architecture.Core.PersonAggregate.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Clean.Architecture.Core.PersonAggregate.Handlers;

/// <summary>
/// NOTE: Internal because PersonDeleted is also marked as internal.
/// </summary>
internal class PersonDeletedHandler(ILogger<PersonDeletedHandler> _logger) : INotificationHandler<PersonDeletedEvent>
{
  public async Task Handle(PersonDeletedEvent domainEvent, CancellationToken cancellationToken)
  {
    _logger.LogInformation("Handling Contributed Deleted event for {personId}", domainEvent.PersonId);

    // TODO: do meaningful work here
    await Task.Delay(1);
  }
}
