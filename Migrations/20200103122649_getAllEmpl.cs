using Microsoft.EntityFrameworkCore.Migrations;

namespace bootstrap.Migrations
{
    public partial class getAllEmpl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[GetEmployees]
                    AS
                    SELECT * FROM Employees 
                ";

            migrationBuilder.Sql(sp);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
