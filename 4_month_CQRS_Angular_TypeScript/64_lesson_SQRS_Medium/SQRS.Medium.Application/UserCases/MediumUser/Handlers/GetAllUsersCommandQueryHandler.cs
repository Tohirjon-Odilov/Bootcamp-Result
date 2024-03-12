using Microsoft.EntityFrameworkCore;
using SQRS.Medium.Application.Abstractions;
using SQRS.Medium.Application.UserCases.MediumUser.Querys;
using SQRS.Medium.Domain.Entities;

namespace SQRS.Medium.Application.UserCases.MediumUser.Handlers
{
    public class GetAllUsersCommandQueryHandler
    {
        private readonly IApplicationDbContext _context;

        public GetAllUsersCommandQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> Handle(GetAllUsersCommandQuery request, CancellationToken cancellationToken)
        {
            var s = _context.Users.Select(x => x).Where(s => s.IsDeleted == false);
            return await s.ToListAsync();
        }
    }
}
