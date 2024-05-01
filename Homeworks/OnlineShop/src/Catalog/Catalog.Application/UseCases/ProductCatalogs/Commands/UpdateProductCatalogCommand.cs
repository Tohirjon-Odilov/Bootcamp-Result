using Catalog.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.UseCases.ProductCatalogs.Commands
{
    public class UpdateProductCatalogCommand : IRequest<ResponceModel>
    {
        public Guid Id { get; set; }
        public string Name {  get; set; }
        public string Description { get; set; }
    }
}
