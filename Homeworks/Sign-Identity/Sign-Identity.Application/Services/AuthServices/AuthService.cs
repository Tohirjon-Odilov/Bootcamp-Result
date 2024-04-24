﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sign_Identity.Domain.DTOs;
using Sign_Identity.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sign_Identity.Application.Services.AuthServices
{

    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(IConfiguration configuration, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<AuthDTO> GenerateToken(User user)
        {

            if (user is null)
            {
                return new AuthDTO()
                {
                    Message = "User is Null",
                    StatusCode = 404
                };
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("JWTSettings").GetSection("SecretKey").Value!);
            //var key = Encoding.ASCII.GetBytes(_configuration["JWTSettings:SecurityKey"]!);

            var roles = await _userManager.GetRolesAsync(user);

            List<Claim> claims =
                [
                    new(JwtRegisteredClaimNames.Email, user.Email!),
                    new(JwtRegisteredClaimNames.Name, user.FirstName),
                    new(JwtRegisteredClaimNames.Name, user.LastName),
                    new(JwtRegisteredClaimNames.UniqueName, user.UserName!),
                    new(JwtRegisteredClaimNames.NameId, user.Id),
                    new(JwtRegisteredClaimNames.Aud, _configuration["JWTSettings:ValidAudience"]!),
                    new(JwtRegisteredClaimNames.Iss, _configuration["JWTSettings:ValidIssuer"]!),
                    new(JwtRegisteredClaimNames.Exp, _configuration["JWTSettings:ExpireDate"]!),
                    //new(ClaimTypes.Role, "Admin")
                ];

            foreach (string role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenDeskriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(Double.Parse(_configuration["JWTSettings:ExpireDate"]!)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key)
                , SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDeskriptor);

            return new AuthDTO()
            {
                Token = tokenHandler.WriteToken(token),
                Message = "Succsessfully created token",
                StatusCode = 200,
                IsSuccess = true
            };


        }
    }
}
