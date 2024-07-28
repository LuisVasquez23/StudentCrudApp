using Microsoft.EntityFrameworkCore;
using StudentCrudApp.Models;

namespace StudentCrudApp.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<StudentEntity> Students { get; set; }    

    }
}
