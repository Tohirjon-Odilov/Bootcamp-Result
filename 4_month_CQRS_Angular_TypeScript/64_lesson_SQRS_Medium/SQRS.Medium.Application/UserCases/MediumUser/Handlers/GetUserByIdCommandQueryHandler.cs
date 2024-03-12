using Microsoft.EntityFrameworkCore;
using SQRS.Medium.Application.Abstractions;
using SQRS.Medium.Application.UserCases.MediumUser.Querys;
using SQRS.Medium.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQRS.Medium.Application.UserCases.MediumUser.Handlers
{
    public class GetUserByIdCommandQueryHandler
    {
        private readonly IApplicationDbContext _context;

        public GetUserByIdCommandQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(GetUserByIdCommandQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id && x.IsDeleted == false);
            if (res == null)
            {
                throw new Exception("User not found")!;
            }
            return res;
        }
    }
}
