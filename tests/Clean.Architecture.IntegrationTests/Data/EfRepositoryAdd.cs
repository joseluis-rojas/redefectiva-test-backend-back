using Clean.Architecture.Core.PersonAggregate;
using Xunit;

namespace Clean.Architecture.IntegrationTests.Data;

public class EfRepositoryAdd : BaseEfRepoTestFixture
{
  [Fact]
  public async Task AddsPersonAndSetsId()
  {
    var testPersonName = "testPerson";
    var testPersonLastName = "testLastName";  // Proporciona un valor para lastName
    var testPersonAddress = "testAddress";    // Proporciona un valor para address
    var testPersonGender = "testGender";      // Proporciona un valor para gender
    var testPersonPhoneNumber = "testPhoneNumber";  // Proporciona un valor para phoneNumber

    var testPersonStatus = PersonStatus.NotSet;
    var repository = GetRepository();
    var person = new Person(testPersonName, testPersonLastName, testPersonAddress, testPersonGender, testPersonPhoneNumber);

    await repository.AddAsync(person);

    var newPerson = (await repository.ListAsync())
                    .FirstOrDefault();

    Assert.Equal(testPersonName, newPerson?.Name);
    Assert.Equal(testPersonLastName, newPerson?.LastName);
    Assert.Equal(testPersonAddress, newPerson?.Address);
    Assert.Equal(testPersonGender, newPerson?.Gender);
    Assert.Equal(testPersonPhoneNumber, newPerson?.PhoneNumber);
    Assert.Equal(testPersonStatus, newPerson?.Status);
    Assert.True(newPerson?.Id > 0);
  }
}
