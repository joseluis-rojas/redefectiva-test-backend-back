using Clean.Architecture.Core.PersonAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Architecture.Infrastructure.Data;

public static class SeedData
{
  public static readonly Person Person1 = new("Persona 1", "Apellido 1", "Direccion 1", "Masculino", "123456");
  public static readonly Person Person2 = new("Persona 2", "Apellido 2", "Direccion 2", "Masculino", "987456");

  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var dbContext = new AppDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
    {
      // Look for any Persons.
      if (dbContext.Persons.Any())
      {
        return;   // DB has been seeded
      }

      PopulateTestData(dbContext);
    }
  }
  public static void PopulateTestData(AppDbContext dbContext)
  {
    foreach (var item in dbContext.Persons)
    {
      dbContext.Remove(item);
    }
    dbContext.SaveChanges();

    dbContext.Persons.Add(Person1);
    dbContext.Persons.Add(Person2);

    dbContext.SaveChanges();
  }
}
