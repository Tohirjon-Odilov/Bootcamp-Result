using Discount.Application.Abstractions;
using Discount.Application.UseCases.Commands;
using Discount.Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Discount.Application.UseCases.Handlers.CommandHandlers
{
    public class UpdateDiscountCommandHandler : IRequestHandler<UpdateDiscountCommand, ResponceModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateDiscountCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ResponceModel> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _applicationDbContext.Discounts.FirstOrDefaultAsync(x => x.Id == request.Id);
                if (result == null)
                {
                    return new ResponceModel()
                    {
                        Message = "Not found",
                        IsSuccess = false,
                        StatusCode = 404
                    };
                }

                result.StartedDate = request.StartedDate;
                result.EndedTime = request.EndedTime;
                result.ProductId = request.ProductId;
                result.CuponCode = request.CuponCode;

                await _applicationDbContext.SaveChanagesAsync(cancellationToken);

                return new ResponceModel()
                {
                    Message = "Successfully updated",
                    StatusCode = 200,
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new ResponceModel()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = 500
                };
            }
        }
    }
}
