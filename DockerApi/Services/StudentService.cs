using DockerApi.Entities;
using DockerApi.Repositories;

namespace DockerApi.Services;

public class StudentService(IStudentRepository studentRepository) : IStudentService
{
    public async Task<int> CreateAsync(Student student)
    {
        await studentRepository.CreateAsync(student);

        return student.Id;
    }

    public async Task<List<Student>> GetAllAsync()
    {
        return await studentRepository.GetAllAsync();
    }
}
