using Microsoft.EntityFrameworkCore;
using StudentCrudApp.Data;
using StudentCrudApp.Models;
using StudentCrudApp.ViewModels;

namespace StudentCrudApp.Manager
{
    public class StudentManager : IStudentManager
    {

        private readonly AppDbContext _context;

        public StudentManager(AppDbContext context)
        {
            _context = context; 
        }


        public async Task<List<StudentEntity>> GetAll(int page = 1, int pageSize = 10)
        {
            var students = await _context.Students
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return students;
        }

        public async Task<StudentEntity> GetById(int id)
        {
            return await _context!.Students!.FindAsync(id) ?? throw new ArgumentNullException("Usuario no encontrado");
        }

        public async Task<StudentEntity> Create(StudentViewModel model)
        {
            var student = new StudentEntity
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Birthday = model.Birthday,
                Email = model.Email
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return student;
        }

        public async Task<string> Update(StudentViewModel model)
        {
            var student = await _context.Students.FindAsync(model.Id);
            if (student == null)
            {
                throw new ArgumentNullException("Usuario no encontrado");
            }

            student.FirstName = model.FirstName;
            student.LastName = model.LastName;
            student.Birthday = model.Birthday;
            student.Email = model.Email;

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return "Usuario guardado exitosamente";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(model.Id))
                {
                    throw new ArgumentNullException("Usuario no encontrado");
                }
                else
                {
                    throw new ArgumentNullException("Sucedio un error de concurrencia");
                }
            }
        }

        public async Task<string> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                throw new ArgumentNullException("Usuario no encontrado");
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return "Usuario actualizado exitosamente";
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
