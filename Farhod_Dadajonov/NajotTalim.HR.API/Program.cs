var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();  

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var allowedhosts = app.Configuration.GetValue<string>("AllowedHosts", string.Empty);
Console.WriteLine(allowedhosts);

var hosts = app.Configuration.GetValue<string>("Kestrel:Endpoints:Http:Url", "Unknown url");
Console.WriteLine(hosts);

app.Run();
