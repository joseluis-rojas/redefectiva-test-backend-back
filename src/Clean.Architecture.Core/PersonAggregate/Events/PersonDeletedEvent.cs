using Ardalis.SharedKernel;

namespace Clean.Architecture.Core.PersonAggregate.Events;

/// <summary>
/// A domain event that is dispatched whenever a person is deleted.
/// The DeletePersonService is used to dispatch this event.
/// </summary>
internal sealed class PersonDeletedEvent(int personId) : DomainEventBase
{
  public int PersonId { get; init; } = personId;
}
