using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentContext _context;
        public StudentRepository(StudentContext context)
        {
            _context = context;
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<IReadOnlyList<Student>> GetStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> InsertStudentAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> UpdateStudentAsync(int id, Student student)
        {
            Student studentToUpdate = await GetStudentByIdAsync(id);
            studentToUpdate.Name = student.Name;
            studentToUpdate.LastName = student.LastName;
            studentToUpdate.Age = student.Age;
            studentToUpdate.Address = student.Address;
            studentToUpdate.Email = student.Email;
            studentToUpdate.PhoneNumber = student.PhoneNumber;

            _context.Students.Update(studentToUpdate);
            await _context.SaveChangesAsync();

            return studentToUpdate;

        }

        public async Task<Student> DeleteStudentAsync(int studentId)
        {
            Student studentToDelete = await GetStudentByIdAsync(studentId);

            _context.Students.Remove(studentToDelete);

            await _context.SaveChangesAsync();

            return studentToDelete;
        }

    }
}