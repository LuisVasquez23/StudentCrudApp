using Microsoft.EntityFrameworkCore;
using StudentCrudApp.Models;
using StudentCrudApp.ViewModels;

namespace StudentCrudApp.Manager
{
    public interface IStudentManager
    {
        Task<List<StudentEntity>> GetAll(int page = 1, int pageSize = 10);
        Task<StudentEntity> GetById(int id);
        Task<StudentEntity> Create(StudentViewModel model);
        Task<string> Update(StudentViewModel model);
        Task<string> Delete(int id);

    }
}
