using Catalog.Application.Abstractions;
using Catalog.Application.UseCases.ProductCatalogs.Commands;
using Catalog.Domain.DTOs;
using Catalog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.UseCases.ProductCatalogs.Handlers.CommandHandlers
{
    public class CreateProductCatalogCommandHandler : IRequestHandler<CreateProductCatalogCommand, ResponceModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateProductCatalogCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ResponceModel> Handle(CreateProductCatalogCommand request, CancellationToken cancellationToken)
        {
            try
            {
                ProductCatalog catalog = new ProductCatalog()
                {
                    Name = request.Name,
                    Description = request.Description,
                    IsDeleted = false
                };

                await _applicationDbContext.ProductCatalogs.AddAsync(catalog);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);

                return new ResponceModel()
                {
                    IsSuccess = true,
                    Message = "Successfully Created",
                    StatusCode = 201
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
