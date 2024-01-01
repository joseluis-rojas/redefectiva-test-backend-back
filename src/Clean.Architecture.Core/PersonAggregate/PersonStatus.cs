using Ardalis.SmartEnum;

namespace Clean.Architecture.Core.PersonAggregate;

public class PersonStatus : SmartEnum<PersonStatus>
{
  public static readonly PersonStatus CoreTeam = new(nameof(CoreTeam), 1);
  public static readonly PersonStatus Community = new(nameof(Community), 2);
  public static readonly PersonStatus NotSet = new(nameof(NotSet), 3);

  protected PersonStatus(string name, int value) : base(name, value) { }
}

