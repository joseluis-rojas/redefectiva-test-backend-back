using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Web.Endpoints.PersonEndpoints;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class GetPersonValidator : Validator<GetPersonByIdRequest>
{
  public GetPersonValidator()
  {
    RuleFor(x => x.PersonId)
      .GreaterThan(0);
  }
}
