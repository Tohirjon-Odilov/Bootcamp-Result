using Discount.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.UseCases.Commands
{
    public class UpdateDiscountCommand : IRequest<ResponceModel>
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string CuponCode { get; set; }
        public DateTimeOffset StartedDate { get; set; }
        public DateTimeOffset EndedTime { get; set; }
    }
}
