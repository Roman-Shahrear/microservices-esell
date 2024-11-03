namespace Catalog.API.Products.CreateProduct
{
    // Command for product creation (DTO)
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal price)
        : ICommand<CreateProductResult>;

    // Result after product creation (DTO)
    public record CreateProductResult(Guid Id);

    internal class CreateProductCommandHandler(IDocumentSession session) 
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // create product entity from command object
            var product = new Product
           {
               Name = command.Name,
               Category = command.Category,
               Description = command.Description,
               ImageFile = command.ImageFile,
               price = command.price
           };

            // save database
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);
            // return result
            return new CreateProductResult(product.Id);
        }
    }
}
