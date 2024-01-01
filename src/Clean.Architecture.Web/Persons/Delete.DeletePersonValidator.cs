using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Web.Endpoints.PersonEndpoints;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class DeletePersonValidator : Validator<DeletePersonRequest>
{
  public DeletePersonValidator()
  {
    RuleFor(x => x.PersonId)
      .GreaterThan(0);
  }
}
