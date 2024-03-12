using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQRS.Medium.Application.UserCases.MediumUser.Commands
{
    public class DeleteUserCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Password { get; set; }
    }
}
