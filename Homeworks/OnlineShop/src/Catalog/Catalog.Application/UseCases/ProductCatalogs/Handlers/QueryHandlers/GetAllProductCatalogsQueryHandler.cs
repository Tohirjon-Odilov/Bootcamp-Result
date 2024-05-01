using Catalog.Application.Abstractions;
using Catalog.Application.UseCases.ProductCatalogs.Queries;
using Catalog.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.UseCases.ProductCatalogs.Handlers.QueryHandlers
{
    public class GetAllProductCatalogsQueryHandler : IRequestHandler<GetAllProductCatalogsQuery, IEnumerable<ProductCatalog>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetAllProductCatalogsQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<ProductCatalog>> Handle(GetAllProductCatalogsQuery request, CancellationToken cancellationToken)
        {
            return await _applicationDbContext.ProductCatalogs.Where(x => x.IsDeleted == false).ToListAsync(cancellationToken);
        }
    }
}
