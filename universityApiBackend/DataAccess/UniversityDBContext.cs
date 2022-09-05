using Microsoft.EntityFrameworkCore;
using universityApiBackend.Models.DataModels;

namespace universityApiBackend.DataAccess
{
    public class UniversityDBContext : DbContext
    {   
        //ActivatorUtilitiesConstructorAttribute Method
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options) : base(options)
        {

        }

        // TODO: Add DbSets (The tables of data base)
        public DbSet<User>? Users { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Chapter>? Chapters { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Student> Students { get; set; }
        

    }
}
