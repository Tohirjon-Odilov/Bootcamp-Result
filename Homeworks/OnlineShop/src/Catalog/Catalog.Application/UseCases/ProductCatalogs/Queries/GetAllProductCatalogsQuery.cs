using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.UseCases.ProductCatalogs.Queries
{
    public class GetAllProductCatalogsQuery : IRequest<IEnumerable<ProductCatalog>>
    {
    }
}
