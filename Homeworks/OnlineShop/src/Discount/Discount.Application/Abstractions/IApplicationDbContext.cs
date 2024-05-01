using Discount.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Abstractions
{
    public interface IApplicationDbContext
    {
        DbSet<ProductDiscount> Discounts { get; set; }

        ValueTask<int> SaveChanagesAsync(CancellationToken cancellationToken = default!);
    }
}
