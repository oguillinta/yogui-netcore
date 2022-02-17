using Core.Entities;

namespace Core.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student> GetStudentByIdAsync(int id);
        Task<IReadOnlyList<Student>> GetStudentsAsync();
        Task<Student> InsertStudentAsync(Student student);
        Task<Student> UpdateStudentAsync(int id, Student student);
        Task<Student> DeleteStudentAsync(int student);
        
    }
}