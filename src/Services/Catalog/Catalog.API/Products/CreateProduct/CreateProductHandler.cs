namespace Catalog.API.Products.CreateProduct
{
    // Command for product creation (DTO)
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
        : ICommand<CreateProductResult>;

    // Result after product creation (DTO)
    public record CreateProductResult(Guid Id);

    // Fluent Validation
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price must be greater then 0");
        }
    }
    internal class CreateProductCommandHandler
        (IDocumentSession session, ILogger<CreateProductCommandHandler> logger) 
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // Log the start of the operation
            logger.LogInformation("CreateProductHandler.Handle called with {@Command}", command);
            try
            {
                
                // create product entity from command object
                var product = new Product
                {
                    Name = command.Name,
                    Category = command.Category,
                    Description = command.Description,
                    ImageFile = command.ImageFile,
                    Price = command.Price

                };

                // save database
                session.Store(product);
                await session.SaveChangesAsync(cancellationToken);
                logger.LogInformation("Product {ProductName} created successfully with ID: {ProductId}", product.Name, product.Id);
                // return result
                return new CreateProductResult(product.Id);
            }
            catch(Exception ex)
            {   
                logger.LogError(ex, "An error occurred while creating the product: {Message}", ex.Message);
                // Handle other exception such as database errors
                throw;
            }
            finally
            {
                logger.LogInformation("Product creation process finished for for {ProductName}", command.Name);
            }
        }
    }
}
