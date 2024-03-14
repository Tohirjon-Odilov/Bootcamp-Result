using RecipeManagement.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagement.Application.Abstractions
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}
