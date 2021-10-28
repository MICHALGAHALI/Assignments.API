using Microsoft.EntityFrameworkCore.Migrations;

namespace assignments_api.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO [dbo].[Types]
           ([Title])
            VALUES
           ('Study'),
		   ('personal'),
		   ('work')");
        //     migrationBuilder.Sql(@"
        //     INSERT INTO [dbo].[Assignments]
        //    ([Title]
        //    ,[Completed]
        //    ,[Type]
        //    ,[Description]
        //    ,[StartDate]
        //    ,[FinishDate]
        //    ,[IsRepeated])
        //     VALUES
        //         ('[Title]',
        //         1,
        //         1,
        //         'Description',
        //         getdate(),
        //         getdate(),
        //         0)
        //     ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.Sql(@"truncate table [dbo].[Assignments]");
             migrationBuilder.Sql(@"DELETE FROM  [dbo].[Types] DBCC CHECKIDENT ('test1.dbo.Types',RESEED, 0)");

        }
    }
}
