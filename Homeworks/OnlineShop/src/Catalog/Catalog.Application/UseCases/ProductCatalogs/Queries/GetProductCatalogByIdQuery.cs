using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.UseCases.ProductCatalogs.Queries
{
    public class GetProductCatalogByIdQuery : IRequest<ProductCatalog>
    {
        public Guid Id { get; set; }
    }
}
