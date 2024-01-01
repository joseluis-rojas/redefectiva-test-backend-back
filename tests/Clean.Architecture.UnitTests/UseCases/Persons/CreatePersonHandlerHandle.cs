using System.Net;
using System.Xml.Linq;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.PersonAggregate;
using Clean.Architecture.UseCases.Persons.Create;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Clean.Architecture.UnitTests.UseCases.Persons;

public class CreatePersonHandlerHandle
{
  private readonly string _testName = "test name";
  private readonly string _testLastName = "test last name";
  private readonly string _testAddress = "test address";
  private readonly string _testGender = "Masculino";
  private readonly string _testPhoneNumber = "789456123";

  private readonly IRepository<Person> _repository = Substitute.For<IRepository<Person>>();
  private CreatePersonHandler _handler;

  public CreatePersonHandlerHandle()
  {
    _handler = new CreatePersonHandler(_repository);
  }

  [Fact]
  public async Task ReturnsSuccessGivenValidName()
  {
    // Configure the repository to return a Task<Person> when AddAsync is called
    _repository.AddAsync(Arg.Any<Person>(), Arg.Any<CancellationToken>())
        .Returns(Task.FromResult(new Person(_testName, _testLastName, _testAddress, _testGender, _testPhoneNumber)));

    // Use the handler to handle the command with all details
    var result = await _handler.Handle(new CreatePersonCommand(_testName, _testLastName, _testAddress, _testGender, _testPhoneNumber), CancellationToken.None);

    // Assert that the result is successful
    result.IsSuccess.Should().BeTrue();
  }
}
