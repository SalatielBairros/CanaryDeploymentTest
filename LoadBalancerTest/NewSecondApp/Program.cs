using Microsoft.AspNetCore.HttpOverrides;
using Repository;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string redisConnectionString = configuration.GetConnectionString("Redis");

builder.Services.AddSingleton<IInsertRecord>(new InsertRecord(redisConnectionString));

// Program.cs ou Startup.cs
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    // Habilita o uso dos cabe�alhos que o NGINX envia
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor |
        ForwardedHeaders.XForwardedProto |
        ForwardedHeaders.XForwardedHost;

    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

var app = builder.Build();
app.UsePathBase(new PathString("/api/balance/new-second"));


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
