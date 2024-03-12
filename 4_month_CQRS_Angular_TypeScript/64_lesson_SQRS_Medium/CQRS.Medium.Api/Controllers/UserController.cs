using MediatR;
using Microsoft.AspNetCore.Mvc;
using SQRS.Medium.Application.UserCases.MediumUser.Commands;
using SQRS.Medium.Application.UserCases.MediumUser.Querys;
using SQRS.Medium.Domain.Entities;

namespace CQRS.Medium.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task CreateUser(CreateUserCommand cuc)
        {
            var s = await _mediator.Send(cuc);
        }
        [HttpGet]
        public async Task<List<User>> GetAllUsers()
        {
            var s = await _mediator.Send(new GetAllUsersCommandQuery());
            return s;
        }
        [HttpGet]
        public async Task<User> GetUserById(int id)
        {
            var s = await _mediator.Send(new GetUserByIdCommandQuery() { Id = id });
            return s;
        }
        [HttpDelete]
        public async Task<string> DeleteUser(DeleteUserCommand dl)
        {
            var s = await _mediator.Send(dl);
            return s;
        }
        [HttpPut]
        public async Task<string> Update(UpdateUserCommand uuc)
        {
            var s = await _mediator.Send(uuc);
            return s;
        }
    }
}
