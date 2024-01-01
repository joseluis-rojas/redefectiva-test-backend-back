using Clean.Architecture.UseCases.Persons;
using Clean.Architecture.UseCases.Persons.List;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Infrastructure.Data.Queries;
public class ListPersonsQueryService : IListPersonsQueryService
{
  private readonly AppDbContext _db;

  public ListPersonsQueryService(AppDbContext db)
  {
    _db = db ?? throw new ArgumentNullException(nameof(db));
  }

  public async Task<IEnumerable<PersonDTO>> ListAsync()
  {
    var result = await _db.Persons
        .FromSqlRaw("SELECT Id, Name, LastName, Address, Gender, PhoneNumber, Status FROM Persons")
        .ToListAsync();

    // Realiza la conversión explícita de Person a PersonDTO
    var personDTOs = result.Select(person => new PersonDTO(
            person.Id,
            person.Name,
            person.LastName, 
            person.Address,
            person.Gender,
            person.PhoneNumber,
            person.Status
        )).ToList();


    return personDTOs;
  }
}

