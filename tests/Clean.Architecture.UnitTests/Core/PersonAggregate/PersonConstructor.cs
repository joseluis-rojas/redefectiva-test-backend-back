using Clean.Architecture.Core.PersonAggregate;
using Xunit;

namespace Clean.Architecture.UnitTests.Core.PersonAggregate;

public class PersonConstructor
{
  [Fact]
  public void CanCreatePerson()
  {
    // Arrange
    var name = "John";
    var lastName = "Doe"; // Asegúrate de proporcionar un valor no nulo para lastName
    var address = "123 Main St";
    var gender = "Male";
    var phoneNumber = "555-1234";

    // Act
    var person = new Person(name, lastName, address, gender, phoneNumber);

    // Assert
    // Agrega tus afirmaciones según sea necesario
    Assert.NotNull(person);
    Assert.Equal(name, person.Name);
    Assert.Equal(lastName, person.LastName);
    Assert.Equal(address, person.Address);
    Assert.Equal(gender, person.Gender);
    Assert.Equal(phoneNumber, person.PhoneNumber);
  }
}

