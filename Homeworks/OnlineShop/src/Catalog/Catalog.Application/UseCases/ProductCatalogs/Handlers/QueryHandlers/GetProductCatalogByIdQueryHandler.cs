using Catalog.Application.Abstractions;
using Catalog.Application.UseCases.ProductCatalogs.Queries;
using Catalog.Domain.Entities;
using Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.UseCases.ProductCatalogs.Handlers.QueryHandlers
{
    public class GetProductCatalogByIdQueryHandler : IRequestHandler<GetProductCatalogByIdQuery, ProductCatalog>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetProductCatalogByIdQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ProductCatalog> Handle(GetProductCatalogByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _applicationDbContext.ProductCatalogs.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == request.Id);

            if (result == null)
            {
                throw new _404NotFoundException("Product Catalog not found");
            }

            return result;
        }
    }
}
