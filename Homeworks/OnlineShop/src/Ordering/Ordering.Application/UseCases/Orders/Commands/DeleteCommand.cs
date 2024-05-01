using MediatR;
using Ordering.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.UseCases.Orders.Commands
{
    public class DeleteCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
    }
}
