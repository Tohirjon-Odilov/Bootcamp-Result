using Catalog.Application.UseCases.ProductCatalogs.Commands;
using Catalog.Application.UseCases.ProductCatalogs.Queries;
using MediatR;
using Catalog.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCatalogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductCatalogController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCatalogCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _mediator.Send(new GetAllProductCatalogsQuery());
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var res = await _mediator.Send(new GetProductCatalogByIdQuery()
            {
                Id = id
            });
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var res = await _mediator.Send(new DeleteProductCatalogCommand()
            {
                Id = id
            });
            return Ok(res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateProductDTO product)
        {
            var command = new UpdateProductCatalogCommand()
            {
                Id = id,
                Name = product.ProductName,
                Description = product.ProductDescription
            };
            var res = await _mediator.Send(command);
            return Ok(res);
        }

    }
}
