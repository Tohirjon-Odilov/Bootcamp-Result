using RecipeManagement.Application.Abstractions;
using RecipeManagement.Domain.Entities.Models;
using RecipeManagement.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagement.Infrastructure.BaseRepositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(RecipeManagementDbContext context) : base(context)
        {
        }
    }
}
