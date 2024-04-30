using Catalog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.UseCases.CatalogCases.Commands
{
    public class CreateCatalogCommand : IRequest<ResponseModel>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
