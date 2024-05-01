using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Domain.Entities
{
    public class ProductDiscount
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string CuponCode { get; set; }
        public DateTimeOffset StartedDate { get; set; }
        public DateTimeOffset EndedTime { get; set; }
    }
}
