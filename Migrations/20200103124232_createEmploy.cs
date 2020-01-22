using Microsoft.EntityFrameworkCore.Migrations;

namespace bootstrap.Migrations
{
    public partial class createEmploy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            var sp = @"CREATE PROCEDURE [dbo].[createEmployee]
                   @FirstName Varchar(30),
                    @lastName VARCHAR(30),
                    @Nickname varchar(30),
                    @mobile int,
                    @email VARCHAR(30),
                    @address VARCHAR(30),
                    @city VARCHAR(30),
                    @country VARCHAR(30),
                    @DOB VARCHAR(30),
                    @password VARCHAR(30),
                    @status int
                AS
                BEGIN
                    SET NOCOUNT ON;
                    INSERT INTO Employees(firstName, lastName, nickName,mobile,Email,Address,city,country,DOB,Password,status)
VALUES (@FirstName, @lastName,  @Nickname,@mobile,@email,@address,@city,@country,@DOB,@password,@status);
                END
                ";
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
