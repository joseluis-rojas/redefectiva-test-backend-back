﻿namespace Clean.Architecture.UseCases.Persons.List;

/// <summary>
/// Represents a service that will actually fetch the necessary data
/// Typically implemented in Infrastructure
/// </summary>
public interface IListPersonsQueryService
{
  Task<IEnumerable<PersonDTO>> ListAsync();
}
