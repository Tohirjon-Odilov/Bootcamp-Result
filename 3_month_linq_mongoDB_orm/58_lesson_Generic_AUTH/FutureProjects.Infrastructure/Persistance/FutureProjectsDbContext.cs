using Microsoft.EntityFrameworkCore;

namespace FutureProjects.Infrastructure.Persistance
{

    public class FutureProjectsDbContext : DbContext
    {
        public FutureProjectsDbContext(DbContextOptions<FutureProjectsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FutureProjects.Domain.Entities.Models.User> Users { get; set; }
    }


    //public class MyDbContextFactory : IDesignTimeDbContextFactory<FutureProjectsDbContext>
    //{
    //    private readonly IConfiguration _conf;

    //    public MyDbContextFactory(IConfiguration conf)
    //    {
    //        _conf = conf;
    //    }

    //    public FutureProjectsDbContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<FutureProjectsDbContext>();
    //        optionsBuilder.UseNpgsql(_conf.GetConnectionString("FutureProjectsConnectionString"));
    //        throw new System.NotImplementedException();
    //    }
    //}
}
