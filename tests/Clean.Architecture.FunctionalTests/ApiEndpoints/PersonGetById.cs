using Ardalis.HttpClientTestExtensions;
using Clean.Architecture.Infrastructure.Data;
using Clean.Architecture.Web.PersonEndpoints;
using Clean.Architecture.Web.Endpoints.PersonEndpoints;
using Xunit;

namespace Clean.Architecture.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class PersonGetById(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client = factory.CreateClient();

  [Fact]
  public async Task ReturnsSeedPersonGivenId1()
  {
    var result = await _client.GetAndDeserializeAsync<PersonRecord>(GetPersonByIdRequest.BuildRoute(1));

    Assert.Equal(1, result.Id);
    Assert.Equal(SeedData.Person1.Name, result.Name);
  }

  [Fact]
  public async Task ReturnsNotFoundGivenId1000()
  {
    string route = GetPersonByIdRequest.BuildRoute(1000);
    _ = await _client.GetAndEnsureNotFoundAsync(route);
  }
}
