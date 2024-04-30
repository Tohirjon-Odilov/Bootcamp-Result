using Catalog.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.UseCases.CatalogCases.Queries
{
    public class GetAllProductCatalogsQuery : IRequest<IEnumerable<ProductCatalog>>
    {
    }
}
