using DockerApi.Entities;

namespace DockerApi.Services;

public interface IStudentService
{
    Task<int> CreateAsync(Student student);
    Task<List<Student>> GetAllAsync();
}
