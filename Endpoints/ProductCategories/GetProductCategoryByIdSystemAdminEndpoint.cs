using System;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using reymani_web_api.Data;
using reymani_web_api.Endpoints.ProductCategories.Responses;
using reymani_web_api.Endpoints.ProductCategories.Requests;
using reymani_web_api.Services.BlobServices;
using reymani_web_api.Endpoints.Mappers;

namespace reymani_web_api.Endpoints.ProductCategories
{
  public class GetProductCategoryByIdSystemAdminEndpoint : Endpoint<GetProductCategoryByIdRequest, Results<Ok<ProductCategoryResponse>, NotFound, ProblemDetails>>
  {
    private readonly AppDbContext _dbContext;
    private readonly IBlobService _blobService;

    public GetProductCategoryByIdSystemAdminEndpoint(AppDbContext dbContext, IBlobService blobService)
    {
      _dbContext = dbContext;
      _blobService = blobService;
    }

    public override void Configure()
    {
      Get("/product-categories/system-admin/{Id}");
      Summary(s =>
      {
        s.Summary = "Get any product category by Id for system admin";
        s.Description = "Retrieves a single product category by Id, including inactive ones.";
      });
      Roles("SystemAdmin");
    }

    public override async Task<Results<Ok<ProductCategoryResponse>, NotFound, ProblemDetails>> ExecuteAsync(GetProductCategoryByIdRequest req, CancellationToken ct)
    {
      var pc = await _dbContext.ProductCategories.FirstOrDefaultAsync(p => p.Id == req.Id, ct);
      if (pc == null)
        return TypedResults.NotFound();

      var mapper = new ProductCategoryMapper();
      var response = mapper.FromEntity(pc);
      response.Logo = !string.IsNullOrEmpty(pc.Logo)
          ? await _blobService.PresignedGetUrl(pc.Logo, ct)
          : null;

      return TypedResults.Ok(response);
    }
  }
}
