﻿
namespace Catalog.API.Products.DeleteProduct
{
    // command for product deletion (DTO)
    public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;
    
    // result after product deletion (DTO)
    public record DeleteProductResult(bool IsSuccess);

    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Product ID is required");
        }
    }


    internal class DeleteProductCommandHnadler
        (IDocumentSession session, ILogger<DeleteProductCommandHnadler> logger)
        : ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("DeleteProductHandler.Handle called with {@Command}", command);
            session.Delete<Product>(command.Id);
            await session.SaveChangesAsync(cancellationToken);

            return new DeleteProductResult(true);
        }
    }
}
