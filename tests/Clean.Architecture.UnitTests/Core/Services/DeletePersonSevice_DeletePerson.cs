using Ardalis.SharedKernel;
using Clean.Architecture.Core.PersonAggregate;
using Clean.Architecture.Core.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace Clean.Architecture.UnitTests.Core.Services;

public class DeletePersonService_DeletePerson
{
  private readonly IRepository<Person> _repository = Substitute.For<IRepository<Person>>();
  private readonly IMediator _mediator = Substitute.For<IMediator>();
  private readonly ILogger<DeletePersonService> _logger = Substitute.For<ILogger<DeletePersonService>>();

  private readonly DeletePersonService _service;

  public DeletePersonService_DeletePerson()
  {
    _service = new DeletePersonService(_repository, _mediator, _logger);
  }

  [Fact]
  public async Task ReturnsNotFoundGivenCantFindPerson()
  {
    var result = await _service.DeletePerson(0);

    Assert.Equal(Ardalis.Result.ResultStatus.NotFound, result.Status);
  }
}
