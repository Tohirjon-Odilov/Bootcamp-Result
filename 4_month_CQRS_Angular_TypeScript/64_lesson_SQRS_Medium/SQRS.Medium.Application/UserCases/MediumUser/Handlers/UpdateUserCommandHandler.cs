using Microsoft.EntityFrameworkCore;
using SQRS.Medium.Application.Abstractions;
using SQRS.Medium.Application.UserCases.MediumUser.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQRS.Medium.Application.UserCases.MediumUser.Handlers
{
    public class UpdateUserCommandHandler
    {
        private readonly IApplicationDbContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public UpdateUserCommandHandler(IApplicationDbContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.IdFinder && x.IsDeleted == false);
            if (res == null)
            {
                return "Not Found";
            }
            if (!_passwordHasher.Verify(res.PasswordHash, request.LastPassword, res.Salt))
            {
                return "Password incorrect";
            }
            if (!string.IsNullOrEmpty(request.UserName))
            {
                res.UserName = request.UserName;
            }

            if (!string.IsNullOrEmpty(request.Name))
            {
                res.Name = request.Name;
            }

            if (!string.IsNullOrEmpty(request.Email))
            {
                res.Email = request.Email;
            }

            if (!string.IsNullOrEmpty(request.PicturePath))
            {
                res.PicturePath = request.PicturePath;
            }

            if (!string.IsNullOrEmpty(request.Password))
            {
                res.PasswordHash = _passwordHasher.Encrypt(request.Password, res.Salt);
            }

            if (!string.IsNullOrEmpty(request.Biography))
            {
                res.Biography = request.Biography;
            }

            if (!string.IsNullOrEmpty(request.Login))
            {
                res.Login = request.Login;
            }

            if (request.Followers != null)
            {
                res.Followers = request.Followers;
            }

            res.ModifiedDate = DateTimeOffset.UtcNow;

            _context.Users.Update(res);
            await _context.SaveChangesAsync(cancellationToken);

            res.UserName = request.UserName;
            res.Name = request.Name;
            res.Email = request.Email;
            res.PicturePath = request.PicturePath;
            res.PasswordHash = _passwordHasher.Encrypt(request.Password, res.Salt);
            res.Biography = request.Biography;
            res.Login = request.Login;
            res.Followers = request.Followers;
            res.ModifiedDate = DateTimeOffset.UtcNow;
            _context.Users.Update(res);
            await _context.SaveChangesAsync(cancellationToken);
            return "Yangilandi";
        }
    }
}
