using Microsoft.EntityFrameworkCore;

namespace studentapi.Data
{//start of namespace
    public class AppDbContext : DbContext

    {//start of class AppDbContext
        //create a constructor for the AppDbContext class that takes DbContextOptions<AppDbContext> as a parameter and passes it to the base class constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //create a DbSet<Student> property called Students
        public DbSet<Models.Student> Students { get; set; }  //how entity framework know which table exits in our database. 




    }//end of class AppDbContext
}//add of namespace 
