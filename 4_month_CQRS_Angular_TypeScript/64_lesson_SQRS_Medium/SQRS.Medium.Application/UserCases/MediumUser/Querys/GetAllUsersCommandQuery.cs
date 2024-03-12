using MediatR;
using SQRS.Medium.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQRS.Medium.Application.UserCases.MediumUser.Querys
{
    public class GetAllUsersCommandQuery : IRequest<List<User>>
    {
    }
}
