using MediatR;

namespace SQRS.Medium.Application.UserCases.MediumUser.Commands
{
    public class CreateUserCommand : IRequest
    {
        public required string UserName { get; set; }
        public string? Name { get; set; }
        public string? Biography { get; set; }
        public string? Email { get; set; }
        public required string Login { get; set; }
        public string Password { get; set; }
        public string? PicturePath { get; set; }
        public int Followers { get; set; }
    }
}
