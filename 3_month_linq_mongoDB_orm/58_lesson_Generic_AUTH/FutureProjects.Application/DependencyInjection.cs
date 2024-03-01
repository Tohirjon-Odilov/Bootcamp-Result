using FutureProjects.Application.Abstractions.IServices;
using FutureProjects.Application.Services.AuthServices;
using FutureProjects.Application.Services.UserServices;
using Microsoft.Extensions.DependencyInjection;

namespace FutureProjects.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}

//bir hil danniy kesa save qimaslik kerak
//birxil emaildan 2 kishi ro'yhatdan o'tmasligi kerak
//login unique bo'lishi kerak

//groupBy qo'shamiz name ga qarab

//Name = userDTO.Name, Email = userDTO.Email, Login = userDTO.Login, Password = userDTO.Password, Role = userDTO.Role, har bitta polyasini update qilish uchun alohida PATCH api chiqarasilar

//Auth yozib kelish Role and Permission based qlib
