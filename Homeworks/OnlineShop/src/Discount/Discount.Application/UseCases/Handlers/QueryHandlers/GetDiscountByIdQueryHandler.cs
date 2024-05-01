using Discount.Application.Abstractions;
using Discount.Application.UseCases.Queries;
using Discount.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.UseCases.Handlers.QueryHandlers
{
    public class GetDiscountByIdQueryHandler : IRequestHandler<GetDiscountByIdQuery, ProductDiscount>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetDiscountByIdQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ProductDiscount> Handle(GetDiscountByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _applicationDbContext.Discounts.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (result == null)
                throw new Exception("Not found");

            return result;
        }
    }
}
