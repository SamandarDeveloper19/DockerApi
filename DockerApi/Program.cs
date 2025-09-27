using DockerApi.Database;
using DockerApi.Repositories;
using DockerApi.Services;
using Microsoft.EntityFrameworkCore;

namespace DockerApi;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IStudentRepository, StudentRepository>();
        builder.Services.AddScoped<IStudentService, StudentService>();

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        var app = builder.Build();

        if (app.Environment.IsDevelopment() ||
            app.Environment.IsProduction())
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            await db.Database.MigrateAsync();
        }

        if (app.Environment.IsDevelopment() ||
            app.Environment.IsProduction())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }


        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
