﻿namespace reymani_web_api.Endpoints.ShippingsCosts.Request;

public class UpdateShippingCostRequest
{
  public int Id { get; set; }
  public required decimal Cost { get; set; }
}
