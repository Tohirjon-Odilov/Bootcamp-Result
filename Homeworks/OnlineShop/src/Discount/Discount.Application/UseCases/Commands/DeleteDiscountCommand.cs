using Discount.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.UseCases.Commands
{
    public class DeleteDiscountCommand : IRequest<ResponceModel>
    {
        public Guid Id { get; set; }
    }
}
