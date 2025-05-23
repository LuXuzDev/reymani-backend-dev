﻿using FastEndpoints;

using FluentValidation;

namespace reymani_web_api.Endpoints.VehiclesTypes.Requests.Validators;

public class DeleteVehicleTypeRequestValidator : Validator<DeleteVehicleTypeRequest>
{
  public DeleteVehicleTypeRequestValidator()
  {
    RuleFor(e => e.Id)
      .NotEmpty()
      .GreaterThan(0);
  }
}
