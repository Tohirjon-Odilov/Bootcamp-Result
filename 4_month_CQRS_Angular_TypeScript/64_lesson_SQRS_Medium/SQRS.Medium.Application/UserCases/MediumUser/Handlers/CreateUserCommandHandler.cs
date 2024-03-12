using AutoMapper;
using MediatR;
using SQRS.Medium.Application.Abstractions;
using SQRS.Medium.Application.UserCases.MediumUser.Commands;
using SQRS.Medium.Domain.Entities;

namespace SQRS.Medium.Application.UserCases.MediumUser.Handlers
{
    public class CreateUserCommandHandler : AsyncRequestHandler<CreateUserCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _pHash;
        public CreateUserCommandHandler(IApplicationDbContext context, IMapper mapper, IPasswordHasher pHash)
        {
            _context = context;
            _mapper = mapper;
            _pHash = pHash;
        }

        protected async override Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _mapper.Map<User>(request);
                user.Salt = Guid.NewGuid().ToString("N");
                user.PasswordHash = _pHash.Encrypt(request.Password, user.Salt);
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync(cancellationToken);
            } catch
            {
                throw new Exception("Something went wrong in Create")!;
            }
        }
    }
}
