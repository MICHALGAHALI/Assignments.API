using Microsoft.EntityFrameworkCore;

namespace assignments_api.Persistence
{
    public class AssignmentDbContext:DbContext
    {
     public AssignmentDbContext(DbContextOptions<AssignmentDbContext> options)
     :base(options)
     {
         
     }
    //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //     {
    //     optionsBuilder
    //     .UseLoggerFactory(_loggerFactory)
    //     .EnableSensitiveDataLogging(true)
    //     .UseSqlServer(_connectionStrings["MyConnectionStringName "]);
    //     } 
    }
}