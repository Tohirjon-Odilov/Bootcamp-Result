using FutureProjects.Domain.Entities.DTOs;
using FutureProjects.Domain.Entities.Models;
using FutureProjects.Domain.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FutureProjects.Application.Abstractions.IServices
{
    public interface IUserService
    {
        public Task<User> Create(UserDTO userDTO);
        public Task<User> GetByName(string name);
        public Task<User> GetById(int Id);
        public Task<User> GetByEmail(string email);
        public Task<User> GetByLogin(string email);
        public Task<IEnumerable<UserViewModel>> GetAll();
        public Task<bool> Delete(Expression<Func<User, bool>> expression);
        public Task<User> Update(int Id, UserDTO userDTO);
    }
}
