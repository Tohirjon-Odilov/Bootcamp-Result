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
    public class GetAllProductCatalogsQueryHandler : IRequestHandler<GetAllProductCatalogsQuery, IEnumerable<ProductCatalog>>
    {
        private readonly ICatalogDbContext _catalogDbContext;

        public GetAllProductCatalogsQueryHandler(ICatalogDbContext catalogDbContext)
        {
            _catalogDbContext = catalogDbContext;
        }

        public async Task<IEnumerable<ProductCatalog>> Handle(GetAllProductCatalogsQuery request, CancellationToken cancellationToken)
        {
            return await _catalogDbContext.Catalogs.
                Where(x => x.IsDeleted == false).ToListAsync(cancellationToken);
        }
    }
}
