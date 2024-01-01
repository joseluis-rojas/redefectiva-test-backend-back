using Clean.Architecture.Core.PersonAggregate;
using Xunit;

namespace Clean.Architecture.IntegrationTests.Data;

public class EfRepositoryDelete : BaseEfRepoTestFixture
{
  [Fact]
  public async Task DeletesItemAfterAddingIt()
  {
    // add a Person
    var repository = GetRepository();
    var initialName = Guid.NewGuid().ToString();
    var initialLastName = Guid.NewGuid().ToString();
    var initialAddress = Guid.NewGuid().ToString();
    var initialGender = Guid.NewGuid().ToString();
    var initialPhoneNumber = Guid.NewGuid().ToString();
    var Person = new Person(initialName, initialLastName, initialAddress, initialGender, initialPhoneNumber);
    await repository.AddAsync(Person);

    // delete the item
    await repository.DeleteAsync(Person);

    // verify it's no longer there
    Assert.DoesNotContain(await repository.ListAsync(),
     p => p.Name == initialName);

  }
}
