using Catalog.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.App.Abstraction
{
    public interface ICatalogDbContext
    {
        public DbSet<ProductCatalog> catalogs { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
