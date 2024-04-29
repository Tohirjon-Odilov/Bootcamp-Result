using Catalog.App.Abstraction;
using Catalog.App.UseCases.CatalogClasses.Commands;
using Catalog.Domain;
using Catalog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.App.UseCases.CatalogClasses.Handlers.CommandHandlers
{
    public class CreateCatalogCommanHandler : IRequestHandler<CreateCatalogCommand, ResponseModel>
    {
        private readonly ICatalogDbContext _context;

        public CreateCatalogCommanHandler(ICatalogDbContext context)
        {
            _context = context;
        }

        async Task<ResponseModel> IRequestHandler<CreateCatalogCommand, ResponseModel>.Handle(CreateCatalogCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var user = new ProductCatalog
                {
                    Name = "Tohirjon",
                    Description = "Bla bla bla",
                };

                await _context.catalogs.AddAsync(user, cancellationToken);
                await _context.catalogs.AddAsync(user, cancellationToken);

            }
        }
    }
}
