using Discount.Application.Abstractions;
using Discount.Application.UseCases.Queries;
using Discount.Domain.Entities;
using MediatR;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.UseCases.Handlers.QueryHandlers
{
    public class GetAllDiscountsQueryHandler : IRequestHandler<GetAllDiscountsQuery, IEnumerable<ProductDiscount>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetAllDiscountsQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<ProductDiscount>> Handle(GetAllDiscountsQuery request, CancellationToken cancellationToken)
        {
            return await _applicationDbContext.Discounts.ToListAsync();
        }
    }
}
