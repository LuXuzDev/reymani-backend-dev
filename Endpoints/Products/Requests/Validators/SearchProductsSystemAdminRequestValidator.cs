using System;
using FluentValidation;
using FastEndpoints;

namespace reymani_web_api.Endpoints.Products.Requests.Validators;

public class SearchProductsSystemAdminRequestValidator : Validator<SearchProductsSystemAdminRequest>
{
    public SearchProductsSystemAdminRequestValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThan(0);

        RuleFor(x => x.PageSize)
            .GreaterThan(0);
    }
}
