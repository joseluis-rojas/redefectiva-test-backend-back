using Clean.Architecture.Core.PersonAggregate;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Clean.Architecture.IntegrationTests.Data;

public class EfRepositoryUpdate : BaseEfRepoTestFixture
{
  [Fact]
  public async Task UpdatesItemAfterAddingIt()
  {
    // add a Person
    var repository = GetRepository();
    var initialName = Guid.NewGuid().ToString();
    var initialLastName = Guid.NewGuid().ToString();
    var initialAddress = Guid.NewGuid().ToString();
    var initialGender = Guid.NewGuid().ToString();
    var initialPhoneNumber = Guid.NewGuid().ToString();

    var personInstance = new Person(initialName, initialLastName, initialAddress, initialGender, initialPhoneNumber);

    await repository.AddAsync(personInstance);

    // detach the item so we get a different instance
    _dbContext.Entry(personInstance).State = EntityState.Detached;

    // fetch the item and update its title
    var newPerson = (await repository.ListAsync())
        .FirstOrDefault(p => p.Name == initialName && p.LastName == initialLastName && p.Address == initialAddress && p.Gender == initialGender && p.PhoneNumber == initialPhoneNumber);

    if (newPerson == null)
    {
      Assert.NotNull(newPerson);
      return;
    }

    Assert.NotSame(personInstance, newPerson);

    var newName = Guid.NewGuid().ToString();
    newPerson.UpdateName(newName);

    var newLastName = Guid.NewGuid().ToString();
    newPerson.UpdateLastName(newLastName);

    var newAddress = Guid.NewGuid().ToString();
    newPerson.UpdateAddress(newAddress);

    var newGender = Guid.NewGuid().ToString();
    newPerson.UpdateGender(newGender);

    var newPhoneNumber = Guid.NewGuid().ToString();
    newPerson.UpdatePhoneNumber(newPhoneNumber);

    // Update the item
    await repository.UpdateAsync(newPerson);

    // Fetch the updated item
 
    var updatedItem = (await repository.ListAsync())
    .FirstOrDefault(p => p.Name == newName && p.LastName == newLastName && p.Address == newAddress && p.Gender == newGender && p.PhoneNumber == newPhoneNumber);


    Assert.NotNull(updatedItem);
    Assert.NotEqual(personInstance.Name, updatedItem?.Name);
    Assert.NotEqual(personInstance.LastName, updatedItem?.LastName);
    Assert.NotEqual(personInstance.Address, updatedItem?.Address);
    Assert.Equal(personInstance.Gender, updatedItem?.Gender);
    Assert.NotEqual(personInstance.PhoneNumber, updatedItem?.PhoneNumber);
    Assert.Equal(personInstance.Status, updatedItem?.Status);
    Assert.Equal(newPerson.Id, updatedItem?.Id);
  }
}
