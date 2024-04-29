using Catalog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.App.UseCases.CatalogClasses.Commands
{
    internal class CreateCatalogCommand : IRequest<ResponseModel>
    {
    }
}
