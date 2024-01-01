using Clean.Architecture.Core.PersonAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Architecture.Infrastructure.Data.Config;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
  public void Configure(EntityTypeBuilder<Person> builder)
  {
    builder.Property(p => p.Name)
        .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
        .IsRequired();
    builder.Property(p => p.LastName)        
          .IsRequired();

    builder.Property(p => p.Address)        
        .IsRequired();

    builder.Property(p => p.Gender)        
        .IsRequired();

    builder.Property(p => p.PhoneNumber)       
        .IsRequired();

    builder.Property(x => x.Status)
      .HasConversion(
          x => x.Value,
          x => PersonStatus.FromValue(x));
  }
}
