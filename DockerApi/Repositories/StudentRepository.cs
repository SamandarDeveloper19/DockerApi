using DockerApi.Database;
using DockerApi.Entities;

namespace DockerApi.Repositories;

public class StudentRepository(AppDbContext context) : IStudentRepository
{
    public async Task CreateAsync(Student student)
    {
        await context.AddAsync(student);
        await context.SaveChangesAsync();
    }

    public Task<List<Student>> GetAllAsync()
    {
        return Task.FromResult(context.Students.ToList());
    }
}
