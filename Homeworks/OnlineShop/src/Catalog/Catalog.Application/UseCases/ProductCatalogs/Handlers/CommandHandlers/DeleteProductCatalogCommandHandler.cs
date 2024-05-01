using Catalog.Application.Abstractions;
using Catalog.Application.UseCases.ProductCatalogs.Commands;
using Catalog.Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.UseCases.ProductCatalogs.Handlers.CommandHandlers
{
    public class DeleteProductCatalogCommandHandler : IRequestHandler<DeleteProductCatalogCommand, ResponceModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteProductCatalogCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ResponceModel> Handle(DeleteProductCatalogCommand request, CancellationToken cancellationToken)
        {
            var catalog = await _applicationDbContext.ProductCatalogs.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == request.Id);

            if (catalog == null)
            {
                return new ResponceModel()
                {
                    IsSuccess = false,
                    Message = "Catalog Not Found",
                    StatusCode = 404
                };
            }
            try
            {
                catalog.IsDeleted = true;
                catalog.DeletedAt = DateTime.UtcNow;

                _applicationDbContext.ProductCatalogs.Update(catalog);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);

                return new ResponceModel()
                {
                    IsSuccess = true,
                    Message = "Successfully deleted",
                    StatusCode = 203
                };
            }
            catch (Exception ex)
            {
                return new ResponceModel()
                {
                    IsSuccess = false,
                    Message = $"{ex.Message}",
                    StatusCode = 404
                };
            }
        }
    }
}
