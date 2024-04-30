using Catalog.App.Abstraction;
using Catalog.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.App.Persistance
{
    public class CatalogDbContext : DbContext, ICatalogDbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) 
            : base(options) { }

        public DbSet<ProductCatalog> catalogs { get; set; }
        //public DbSet<ProductCatalog> catalogs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
