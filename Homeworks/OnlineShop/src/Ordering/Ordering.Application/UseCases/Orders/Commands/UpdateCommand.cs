using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.UseCases.Orders.Commands
{
    public class UpdateCommand
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public DateTimeOffset OrderedDate { get; set; }
    }
}
