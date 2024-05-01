using Catalog.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.UseCases.ProductCatalogs.Commands
{
    public class DeleteProductCatalogCommand : IRequest<ResponceModel>
    {
        public Guid Id { get; set; }
    }
}
