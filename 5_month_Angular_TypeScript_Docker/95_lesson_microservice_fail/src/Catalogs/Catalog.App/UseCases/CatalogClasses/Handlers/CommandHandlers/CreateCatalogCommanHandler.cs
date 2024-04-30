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

        public async Task<ResponseModel> Handle(CreateCatalogCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var catalog = new ProductCatalog
                {
                    Name = request.Name,
                    Description = request.Description,
                };

                await _context.catalogs.AddAsync(catalog, cancellationToken);
                await _context.SaveChangesAsync( cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"{request.Name} => Created Catalog",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Catalog is maybe null",
                StatusCode = 400,
            };
        }
    }
}
