using Microsoft.EntityFrameworkCore;
using routesharebackend.Data;
using routesharebackend.Hubs;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine("Connection String:");
Console.WriteLine(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();

builder.Services.AddSignalR();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("AllowReact");

app.UseAuthorization();

app.MapControllers();

app.MapHub<RideHub>("/rideHub");

app.Run();