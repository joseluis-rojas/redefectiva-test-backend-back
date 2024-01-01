using Ardalis.HttpClientTestExtensions;
using Clean.Architecture.Infrastructure.Data;
using Clean.Architecture.Web.Endpoints.PersonEndpoints;
using Xunit;

namespace Clean.Architecture.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class PersonList(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client = factory.CreateClient();

  [Fact]
  public async Task ReturnsTwoPersons()
  {
    var result = await _client.GetAndDeserializeAsync<PersonListResponse>("/Persons");

    Assert.Equal(2, result.Persons.Count);
    Assert.Contains(result.Persons, i => i.Name == SeedData.Person1.Name);
    Assert.Contains(result.Persons, i => i.Name == SeedData.Person2.Name);
  }
}
