using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQRS.Medium.Application.UserCases.MediumUser.Commands
{
    public class UpdateUserCommand : IRequest<string>
    {
        public int IdFinder { get; set; }
        public string LastPassword { get; set; }
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
