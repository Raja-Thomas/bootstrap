using Microsoft.EntityFrameworkCore.Migrations;

namespace bootstrap.Migrations
{
    public partial class ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "countryMasters",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countryMasters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(maxLength: 255, nullable: false),
                    lastName = table.Column<string>(maxLength: 255, nullable: false),
                    nickName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Address = table.Column<string>(maxLength: 255, nullable: false),
                    Address2 = table.Column<string>(nullable: true),
                    city = table.Column<string>(maxLength: 255, nullable: false),
                    country = table.Column<string>(maxLength: 255, nullable: false),
                    DOB = table.Column<string>(nullable: false),
                    gender = table.Column<string>(nullable: true),
                    Password = table.Column<string>(maxLength: 255, nullable: false),
                    State = table.Column<string>(nullable: true),
                    ConfirmPassword = table.Column<string>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    mobile = table.Column<string>(maxLength: 255, nullable: false),
                    CountryMasterID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_countryMasters_CountryMasterID",
                        column: x => x.CountryMasterID,
                        principalTable: "countryMasters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CountryMasterID",
                table: "Employees",
                column: "CountryMasterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "countryMasters");
        }
    }
}
