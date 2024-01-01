﻿using Clean.Architecture.Infrastructure.Data.Config;
using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Web.Endpoints.PersonEndpoints;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class CreatePersonValidator : Validator<CreatePersonRequest>
{
  public CreatePersonValidator()
  {
    RuleFor(x => x.Name)
      .NotEmpty()
      .WithMessage("Name is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);

    RuleFor(x => x.LastName)
          .NotEmpty()
          .WithMessage("LastName is required.")
          .MinimumLength(2);

    RuleFor(x => x.Address)
        .NotEmpty()
          .WithMessage("Address is required.")
          .MinimumLength(2); ;

    RuleFor(x => x.Gender)
        .NotEmpty()
          .WithMessage("Gender is required.")
          .MinimumLength(2);

    RuleFor(x => x.PhoneNumber)
        .NotEmpty()
          .WithMessage("PhoneNumber is required.")
          .MinimumLength(2);
  
}
}
