using Notifications.Api.Middlewares;
using SignalRWebpack.Hubs;

var builder = 
    WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials();
    });
});

var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapHub<ChatHub>("/hub");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<MyRateLimiting>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors();
app.MapControllers();
app.MapHub<ChatHub>("/notificationHub");
app.Run();
