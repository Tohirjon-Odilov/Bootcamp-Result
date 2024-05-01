using Discount.Application.Abstractions;
using Discount.Application.UseCases.Commands;
using Discount.Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Discount.Application.UseCases.Handlers.CommandHandlers
{
    public class DeleteDiscountCommandHandler : IRequestHandler<DeleteDiscountCommand, ResponceModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteDiscountCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ResponceModel> Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _applicationDbContext.Discounts.FirstOrDefaultAsync(x => x.Id == request.Id);
                if (result == null)
                {
                    return new ResponceModel()
                    {
                        Message = "Discount Not Found",
                        IsSuccess = false,
                        StatusCode = 404
                    };
                }
                _applicationDbContext.Discounts.Remove(result);
                await _applicationDbContext.SaveChanagesAsync(cancellationToken);
                return new ResponceModel()
                {
                    Message = "Succesfully Deleted",
                    IsSuccess = true,
                    StatusCode = 200
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
