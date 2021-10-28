using assignments_api.Models;
using Microsoft.EntityFrameworkCore;

namespace assignments_api.Persistence
{
    public class AssignmentDbContext:DbContext
    {
     public AssignmentDbContext(DbContextOptions<AssignmentDbContext> options)
     :base(options)
     {
         
     }
    //  protected override void OnModelCreating(ModelBuilder modelBuilder)
	//  {
	// 	foreach(var e in modelBuilder.Model.GetEntityTypes())
	// 	{
	// 		foreach(var fk in e.GetForeignKeys())
	// 		{
	// 			fk.DeleteBehavior = DeleteBehavior.Restrict;
	// 		}
	// 	}
	//  }
     public DbSet<Assignment> Assignments { get; set; }
     public DbSet<Type> Types { get; set; }
      //protected override void OnModelCreating(ModelBuilder modelBuilder)
      //{
        // modelBuilder.Entity<Assignment>()
        //     .HasOne(p => p.IdType)
        //     .WithMany(b => b.Posts)
        //     .HasForeignKey(p => p.BlogUrl)
        //     .HasPrincipalKey(b => b.Url);
    // }
    //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //     {
    //     optionsBuilder
    //     .UseLoggerFactory(_loggerFactory)
    //     .EnableSensitiveDataLogging(true)
    //     .UseSqlServer(_connectionStrings["MyConnectionStringName "]);
    //     } 
    }
}