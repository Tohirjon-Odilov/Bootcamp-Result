using FutureProjects.Application.Abstractions;
using FutureProjects.Domain.Entities.Models;
using FutureProjects.Infrastructure.Persistance;

namespace FutureProjects.Infrastructure.BaseRepositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(FutureProjectsDbContext context) : base(context)
        {
        }
    }
}
