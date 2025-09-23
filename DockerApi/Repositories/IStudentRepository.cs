using DockerApi.Entities;

namespace DockerApi.Repositories;

public interface IStudentRepository
{
    Task CreateAsync(Student student);
    Task<List<Student>> GetAllAsync();
}
