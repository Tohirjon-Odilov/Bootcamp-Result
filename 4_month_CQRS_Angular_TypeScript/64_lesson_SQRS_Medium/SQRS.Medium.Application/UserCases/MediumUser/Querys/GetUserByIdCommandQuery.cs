using MediatR;
using SQRS.Medium.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQRS.Medium.Application.UserCases.MediumUser.Querys
{
    public class GetUserByIdCommandQuery : IRequest<User>
    {
        public int Id { get; set; }
    }
}
