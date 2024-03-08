using FutureProjects.Application.Abstractions;
using FutureProjects.Application.Abstractions.IServices;
using FutureProjects.Domain.Entities.DTOs;
using FutureProjects.Domain.Entities.Models;
using FutureProjects.Domain.Entities.ViewModels;
using FutureProjects.Domain.Exceptions;
using System.Linq.Expressions;

namespace FutureProjects.Application.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Create(UserDTO userDTO)
        {
            User? hasLogin = await _userRepository.GetByAny(x => x.Login == userDTO.Login);
            var hasEmail = await _userRepository.GetByAny(x => x.Email == userDTO.Email);

            if (hasLogin != null && hasEmail != null)
            {
                throw new AlreadyExistException();
            }

            User? user = new User()
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                Login = userDTO.Login,
                Password = userDTO.Password,
                Role = userDTO.Role,
            };

            User? result = await _userRepository.Create(user);

            return result;
        }

        public async Task<bool> Delete(Expression<Func<User, bool>> expression)
        {
            var result = await _userRepository.Delete(expression);

            return result;
        }

        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            var users = await _userRepository.GetAll();

            var result = users.Select(model => new UserViewModel
            {
                Name = model.Name,
                Email = model.Email,
                Role = model.Role,
            });

            return result;
        }

        public async Task<User> GetByAny(Expression<Func<User, bool>> expression)
        {
            var result = await _userRepository.GetByAny(expression);

            return result;
        }

        public async Task<User> GetByEmail(string email)
        {
            var result = await _userRepository.GetByAny(x => x.Email == email);
            return result;
        }

        public async Task<User> GetById(int Id)
        {
            var result = await _userRepository.GetByAny(x => x.Id == Id);
            return result;
        }

        public async Task<User> GetByLogin(string login)
        {
            var reult = await _userRepository.GetByAny(y => y.Login == login);
            return reult;
        }

        public async Task<User> GetByName(string name)
        {
            var result = await _userRepository.GetByAny(d => d.Name == name);
            return result;
        }

        public async Task<User> Update(int Id, UserDTO userDTO)
        {
            var res = await _userRepository.GetByAny(x => x.Id == Id);

            if (res != null)
            {
                var user = new User()
                {
                    Name = userDTO.Name,
                    Email = userDTO.Email,
                    Login = userDTO.Login,
                    Password = userDTO.Password,
                    Role = userDTO.Role,
                };
                var result = await _userRepository.Update(user);

                return result;
            }
            return new User();

        }
    }
}
