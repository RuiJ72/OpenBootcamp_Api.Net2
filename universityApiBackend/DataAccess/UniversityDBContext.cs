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
    }
}
