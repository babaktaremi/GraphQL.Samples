using GraphQL.Samples.Api.Database.Context;
using GraphQL.Samples.Api.Database.EntityModels;
using HotChocolate;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Samples.Api.Queries;

public class ProductsQuery
{
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Product> GetProducts([Service(ServiceKind.Resolver)] AdventureWorksContext context)
        => context.Products.AsNoTracking();
    
    [UseFirstOrDefault]
    [UseProjection]
    [UseFiltering]
    public IQueryable<Product?> GetSingleProduct(int productId,[Service(ServiceKind.Resolver)] AdventureWorksContext context)
        => context.Products.AsNoTracking().Where(c=>c.ProductId==productId);
}