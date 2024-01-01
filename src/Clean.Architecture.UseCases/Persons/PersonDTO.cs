namespace Clean.Architecture.UseCases.Persons;
public record PersonDTO(int Id, string Name, string? LastName, string? Address, string? Gender, string? PhoneNumber, int Status);
