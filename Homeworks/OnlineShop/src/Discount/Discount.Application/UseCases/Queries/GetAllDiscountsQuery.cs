using Discount.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.UseCases.Queries
{
    public class GetAllDiscountsQuery : IRequest<IEnumerable<ProductDiscount>>
    {
    }
}
