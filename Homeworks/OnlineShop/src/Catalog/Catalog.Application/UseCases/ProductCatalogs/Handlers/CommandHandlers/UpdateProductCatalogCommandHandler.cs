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
    public class UpdateProductCatalogCommandHandler : IRequestHandler<UpdateProductCatalogCommand, ResponceModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateProductCatalogCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ResponceModel> Handle(UpdateProductCatalogCommand request, CancellationToken cancellationToken)
        {
            var catalog = await _applicationDbContext.ProductCatalogs.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == request.Id);
            if (catalog == null)
            {
                return new ResponceModel()
                {
                    Message = "Product Catalog not found",
                    StatusCode = 404,
                    IsSuccess = false
                };
            }
            try
            {
                catalog.Name = request.Name;
                catalog.Description = request.Description;
                catalog.ModifiedAt = DateTime.UtcNow;

                _applicationDbContext.ProductCatalogs.Update(catalog);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return new ResponceModel()
                {
                    Message = "Successfully updated",
                    StatusCode = 202,
                    IsSuccess = true
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
