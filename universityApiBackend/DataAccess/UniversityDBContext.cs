using Microsoft.EntityFrameworkCore;


namespace universityApiBackend.DataAccess
{
    public class UniversityDBContext : DbContext
    {   
        //ActivatorUtilitiesConstructorAttribute Method
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options) : base(options)
        {

        }

        // TODO: Add DbSets (The tables of data base)
    }
}
