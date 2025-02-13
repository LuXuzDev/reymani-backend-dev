using System;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using reymani_web_api.Data;
using reymani_web_api.Endpoints.ProductCategories.Responses;
using reymani_web_api.Endpoints.ProductCategories.Requests;
using reymani_web_api.Services.BlobServices;

namespace reymani_web_api.Endpoints.ProductCategories
{
  public class GetProductCategoryByIdEndpoint : Endpoint<GetProductCategoryByIdRequest, Results<Ok<ProductCategoryResponse>, NotFound, ProblemDetails>>
  {
    private readonly AppDbContext _dbContext;
    private readonly IBlobService _blobService;

    public GetProductCategoryByIdEndpoint(AppDbContext dbContext, IBlobService blobService)
    {
      _dbContext = dbContext;
      _blobService = blobService;
    }

    public override void Configure()
    {
      Get("/product-categories/{Id}");
      Summary(s =>
      {
        s.Summary = "Get an active product category by Id";
        s.Description = "Retrieves a single active product category by Id.";
      });
      AllowAnonymous();
    }

    public override async Task<Results<Ok<ProductCategoryResponse>, NotFound, ProblemDetails>> ExecuteAsync(GetProductCategoryByIdRequest req, CancellationToken ct)
    {
      // Buscar la categoría activa por Id
      var pc = await _dbContext.ProductCategories.FirstOrDefaultAsync(p => p.Id == req.Id && p.IsActive, ct);
      if (pc == null)
        return TypedResults.NotFound();

      var response = new ProductCategoryResponse
      {
        Id = pc.Id,
        Name = pc.Name,
        Logo = pc.Logo != null ? await _blobService.PresignedGetUrl(pc.Logo, ct) : null,
        IsActive = pc.IsActive
      };

      return TypedResults.Ok(response);
    }
  }
}
