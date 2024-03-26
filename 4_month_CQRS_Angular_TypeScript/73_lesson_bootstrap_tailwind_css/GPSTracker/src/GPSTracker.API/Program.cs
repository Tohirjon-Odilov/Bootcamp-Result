using GPSTracker.API.Application.Services.AuthServices;
using GPSTracker.API.Application.Services.ClientServices;
using GPSTracker.API.Application.Services.Helpers;
using GPSTracker.API.Application.Services.JWTServices;
using GPSTracker.API.Infrastructure;
using GPSTracker.API.Infrastructure.Broker;
using GPSTracker.API.Infrastructure.Repositories.DeviceRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GpsTracker", Version = "v1.0.0" });
    var securitySchema = new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };
    c.AddSecurityDefinition("Bearer", securitySchema);
    var securityRequirement = new OpenApiSecurityRequirement
                {
                    { securitySchema, new[] { "Bearer" } }
                };
    c.AddSecurityRequirement(securityRequirement);
});

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJWTService, JWTService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options
        .UseLazyLoadingProxies()
        .UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(
        options =>
        {
            options.TokenValidationParameters = GetTokenValidationParameters(builder.Configuration);

            options.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = (context) =>
                {
                    if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                    {
                        context.Response.Headers.Add("IsTokenExpired", "true");
                    }
                    return Task.CompletedTask;
                }
            };
        });

builder.Services.AddHttpClient();
builder.Services.AddScoped<ProGPSAPIService>();

var app = builder.Build();

/*if (app.Environment.IsDevelopment())
{*/
app.UseSwagger();
app.UseSwaggerUI();
/*}*/

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();


static TokenValidationParameters GetTokenValidationParameters(IConfiguration configuration)
{
    return new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = configuration["JWT:Audience"],
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"])),
        ClockSkew = TimeSpan.Zero,
    };
}