using System.Net;
using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace Clean.Architecture.Core.PersonAggregate;

public class Person : EntityBase, IAggregateRoot
{
  public string Name { get; private set; }
  public string LastName { get; private set; }
  public string Address { get; private set; }
  public string Gender { get; private set; }
  public string PhoneNumber { get; private set; }
  public PersonStatus Status { get; private set; } = PersonStatus.NotSet;

  // Constructor
  public Person(
      string name,
      string lastName,
      string address,
      string gender,
      string phoneNumber)
  {
    Name = Guard.Against.NullOrEmpty(name, nameof(name));
    LastName = Guard.Against.NullOrEmpty(lastName, nameof(lastName));
    Address = Guard.Against.NullOrEmpty(address, nameof(address));
    Gender = Guard.Against.NullOrEmpty(gender, nameof(gender));
    PhoneNumber = Guard.Against.NullOrEmpty(phoneNumber, nameof(phoneNumber));
  }

  public void UpdateName(string newName)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
  }

  public void UpdateLastName(string newLastName)
  {
    LastName = Guard.Against.NullOrEmpty(newLastName, nameof(newLastName));
  }

  public void UpdateAddress(string newAddress)
  {
    Address = Guard.Against.NullOrEmpty(newAddress, nameof(newAddress));
  }

  public void UpdateGender(string newGender)
  {
    Gender = Guard.Against.NullOrEmpty(newGender, nameof(newGender));
  }

  public void UpdatePhoneNumber(string newPhoneNumber)
  {
    PhoneNumber = Guard.Against.NullOrEmpty(newPhoneNumber, nameof(newPhoneNumber));
  }
}

