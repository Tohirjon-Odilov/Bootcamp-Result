using Discount.Application.UseCases.Commands;
using Discount.Application.UseCases.Queries;
using Discount.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Discount.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DiscountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDiscountCommand commend)
        {
            var result = await _mediator.Send(commend);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllDiscountsQuery() { });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetDiscountByIdQuery()
            {
                Id = id
            });
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteDiscountCommand()
            {
                Id = id
            });
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateDiscountDTO dto)
        {
            var command = new UpdateDiscountCommand()
            {
                Id = id,
                StartedDate = dto.StartedDate,
                CuponCode = dto.CuponCode,
                EndedTime = dto.EndedTime,
                ProductId = dto.ProductId
            };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
