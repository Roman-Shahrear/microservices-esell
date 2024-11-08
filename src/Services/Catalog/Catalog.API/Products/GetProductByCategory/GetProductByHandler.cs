
namespace Catalog.API.Products.GetProductByCategory
{
    // query product by category (DTO)
    public record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryResult>;
    
    // after result query  product by Category (DTO)
    public record GetProductByCategoryResult(IEnumerable<Product> Products);
    internal class GetProductByCategoryHandler(IDocumentSession session)
        : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            var products = await session.Query<Product>()
                .Where(p => p.Category.Contains(query.Category))
                .ToListAsync();

            return new GetProductByCategoryResult(products);
        }
    }
}
