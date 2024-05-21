using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBrand.Application.Abstractions
{
    public interface IApplicationDbContext
    {
        ValueTask<int> SaveChangesAsync(CancellationToken cancellationToken = default!);
    }
}
