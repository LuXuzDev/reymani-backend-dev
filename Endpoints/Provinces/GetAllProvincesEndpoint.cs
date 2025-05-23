﻿using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

using reymani_web_api.Data;

using reymani_web_api.Endpoints.Mappers;
using reymani_web_api.Endpoints.Provinces.Responses;

namespace reymani_web_api.Endpoints.Provinces;

public class GetAllProvincesEndpoint : EndpointWithoutRequest<Results<Ok<IEnumerable<ProvinceResponse>>, ProblemDetails>>
{
  private readonly AppDbContext _dbContext;


  public GetAllProvincesEndpoint(AppDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public override void Configure()
  {
    Get("/provinces");
    Summary(s =>
    {
      s.Summary = "Get all provinces";
      s.Description = "Retrieves a list of all provinces with municipies.";
    });
    AllowAnonymous();
  }

  public override async Task<Results<Ok<IEnumerable<ProvinceResponse>>, ProblemDetails>> ExecuteAsync(CancellationToken ct)
  {
    var mapper = new ProvinceMapper();

    
    var provinces = await _dbContext.Provinces
        .Include(p => p.Municipalities)
        .AsNoTracking()
        .OrderBy(u => u.Id)
        .ToListAsync(ct);

    var response = provinces.Select(u => mapper.FromEntity(u)).ToList();

    return TypedResults.Ok(response.AsEnumerable());
  }
}

