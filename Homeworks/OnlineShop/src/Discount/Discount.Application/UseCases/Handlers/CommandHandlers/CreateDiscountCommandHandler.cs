using Discount.Application.Abstractions;
using Discount.Application.UseCases.Commands;
using Discount.Domain.DTOs;
using Discount.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.UseCases.Handlers.CommandHandlers
{
    public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand, ResponceModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateDiscountCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ResponceModel> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var discount = new ProductDiscount()
                {
                    ProductId = request.ProductId,
                    CuponCode = request.CuponCode,
                    StartedDate = request.StartedDate,
                    EndedTime = request.EndedTime,
                };

                await _applicationDbContext.Discounts.AddAsync(discount);
                await _applicationDbContext.SaveChanagesAsync(cancellationToken);

                return new ResponceModel()
                {
                    Message = "Discount Created",
                    StatusCode = 201,
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new ResponceModel()
                {
                    Message = ex.Message,
                    StatusCode = 500,
                    IsSuccess = false
                };
            }
        }
    }
}
