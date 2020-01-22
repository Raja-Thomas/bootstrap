using Microsoft.EntityFrameworkCore.Migrations;

namespace bootstrap.Migrations
{
    public partial class initia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[GetStudents]
                      @Id Int
                AS
                BEGIN
                    SET NOCOUNT ON;
                    SELECT * FROM Employees where Id = @Id
                END";

            migrationBuilder.Sql(sp);
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
