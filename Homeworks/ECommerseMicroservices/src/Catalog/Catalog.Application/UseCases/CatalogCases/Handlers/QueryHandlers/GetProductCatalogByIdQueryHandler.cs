using Catalog.Application.Abstractions;
using Catalog.Application.UseCases.CatalogCases.Queries;
using Catalog.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.UseCases.CatalogCases.Handlers.QueryHandlers
{
    //public class GetProductCatalogByIdQueryHandler : IRequestHandler<GetProductCatalogByIdQuery, ProductCatalog>
    //{
    //    private readonly IApplicationDbContext _applicationDbContext;

    //    public GetProductCatalogByIdQueryHandler(IApplicationDbContext applicationDbContext)
    //    {
    //        _applicationDbContext = applicationDbContext;
    //    }

    //    public async Task<ProductCatalog> Handle(GetProductCatalogByIdQuery request, CancellationToken cancellationToken)
    //    {
    //        var result = await _applicationDbContext.ProductCatalogs.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == request.Id);

    //        if (result == null)
    //        {
    //            throw new _404NotFoundException("Product Catalog not found");
    //        }

    //        return result;
    //    }
    //}
    public class GetProductCatalogByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductCatalog>
    {
        private readonly ICatalogDbContext _catalogDbContext;

        public GetProductCatalogByIdQueryHandler(ICatalogDbContext catalogDbContext)
        {
            _catalogDbContext = catalogDbContext;
        }

        public async Task<ProductCatalog> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _catalogDbContext.Catalogs.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == request.Id);

            if (result == null)
            {
                throw new Exception("Product catalog not found");
            }


            return result;
        }
    }
}
