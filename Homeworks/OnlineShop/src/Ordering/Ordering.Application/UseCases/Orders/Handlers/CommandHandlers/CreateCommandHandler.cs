using MediatR;
using Ordering.Application.Abstraction;
using Ordering.Application.UseCases.Orders.Commands;
using Ordering.Domain.DTO;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.UseCases.Orders.Handlers.CommandHandlers
{
    public class CreateCommandHandler:IRequestHandler<CreateCommand, ResponseModel>
    {
        private readonly IOrderingDbContext _orderDbContext;

        public CreateCommandHandler(IOrderingDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        Task<ResponseModel> IRequestHandler<CreateCommand, ResponseModel>.Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            Order order = new Order
            {
                OrderedDate = request.OrderedDate,
                ProductId = request.ProductId,
                UserId = request.UserId,
            };

            _orderDbContext.Orders.Add(order);

            return 
        }

    }
}
