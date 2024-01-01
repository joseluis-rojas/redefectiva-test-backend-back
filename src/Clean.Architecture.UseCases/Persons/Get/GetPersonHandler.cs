using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.PersonAggregate;
using Clean.Architecture.Core.PersonAggregate.Specifications;

namespace Clean.Architecture.UseCases.Persons.Get;

//public class GetPersonHandler(IReadRepository<Person> _repository) : IQueryHandler<GetPersonQuery, Result<PersonDTO>>
  public class GetPersonHandler : IQueryHandler<GetPersonQuery, Result<PersonDTO>>
{
  private readonly IReadRepository<Person> _repository;

  public GetPersonHandler(IReadRepository<Person> repository)
  {
    _repository = repository ?? throw new ArgumentNullException(nameof(repository));
  }
  //public async Task<Result<PersonDTO>> Handle(GetPersonQuery request, CancellationToken cancellationToken)
  public async Task<Result<PersonDTO>> Handle(GetPersonQuery request, CancellationToken cancellationToken)
  {
    var spec = new PersonByIdSpec(request.PersonId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null) return Result.NotFound();

    return new PersonDTO
      (
      entity.Id, 
      entity.Name, 
      entity.LastName, 
      entity.Address, 
      entity.Gender, 
      entity.PhoneNumber,
      entity.Status
      );
  }
}
