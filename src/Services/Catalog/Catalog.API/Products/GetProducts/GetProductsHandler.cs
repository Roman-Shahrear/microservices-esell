
namespace Catalog.API.Products.GetProducts
{
    public record GetProductsQery() : IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> Products);
    internal class GetProductsQueryHandler
        (IDocumentSession session, ILogger<GetProductsQueryHandler> logger)
        : IQueryHandler<GetProductsQery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductsQueryHandler.Handle called with {@Query}", query);

            var products = await session.Query<Product>().ToListAsync(cancellationToken);
            
            return new GetProductsResult(products);
        }
    }
}
