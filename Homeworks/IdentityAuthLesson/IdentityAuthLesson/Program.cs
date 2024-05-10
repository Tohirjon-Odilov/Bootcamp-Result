
using IdentityAuthLesson.Models;
using IdentityAuthLesson.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using System.Text;
using TelegramSink;

namespace IdentityAuthLesson
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<ApplicationIdentityDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IAuthService, AuthService>();

            builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["JWTSettings:ValidIssuer"],
                    ValidAudience = builder.Configuration["JWTSettings:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTSettings:SecretKey"]!))
                };
            });

            var MyPolicy = "_myAllowSpecificOrigins";

            builder.Services.AddCors(options => {
                options.AddPolicy(name: MyPolicy, policy =>
                {
                    policy.AllowAnyHeader()
                           .AllowAnyOrigin()
                           .AllowAnyMethod();
                });
            });


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
            });

            /*
            builder.Services.AddDbContext<IdentityDbContext>(options => options.UseInMemoryDatabase("IdentityDb"));
            builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
            builder.Services.AddAuthorizationBuilder();

            
            builder.Services.AddIdentityCore<IdentityUser>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddApiEndpoints();
            */

//            Log.Logger = new LoggerConfiguration()
    //          .MinimumLevel.Debug()
  //            .WriteTo.Logger(lc => lc
      //            .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Information)
        //          .WriteTo.TeleSink("6450224062:AAGrJR3ezR2t2EyWbTL_oYTsgMLzTnRMai8", "1633746526")
//              .WriteTo.Console()
            //  .WriteTo.File("wwwroot/log.txt")
            //  .CreateLogger();

            builder.Logging.AddSerilog();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            //app.MapIdentityApi<IdentityUser>();
            //app.MapGet("welcome", () => "Salom bolajonim")
            //    .RequireAuthorization();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(MyPolicy);

            app.MapControllers();

            app.Run();
        }
    }
}
