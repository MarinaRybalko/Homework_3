using Microsoft.EntityFrameworkCore.Migrations;

namespace Module4task3.Migrations
{
    public partial class AddClientTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientId",
                table: "Project",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Client_ClientId",
                table: "Project",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.Sql(@"insert into Client(FirstName, LastName, Phone, Email) values('Ann', 'Ray', '12344', 'ann@gmail.com')
                                   insert into Client(FirstName, LastName, Phone, Email) values('Mey', 'Lay', '7777', 'lay@gmail.com')
                                   insert into Client(FirstName, LastName, Phone, Email) values('Ser', 'Het', '12121', 'het@gmail.com')
                                   insert into Client(FirstName, LastName, Phone, Email) values('Wuu', 'Vuu', '21311', 'we@gmail.com')
                                   insert into Client(FirstName, LastName, Phone, Email) values('Sdd', 'Ber', '454', 'ber@gmail.com')");

            migrationBuilder.Sql(@"insert into Project(Name, Budget, StartedDate, ClientId) values('Test project 1', 1600, '2020-10-01', 1)
                                   insert into Project(Name, Budget, StartedDate, ClientId) values('Test project 2', 1990, '2020-09-11', 1)
                                   insert into Project(Name, Budget, StartedDate, ClientId) values('Test project 3', 1400, '2020-03-13', 2)
                                   insert into Project(Name, Budget, StartedDate, ClientId) values('Test project 4', 160, '2020-04-11', (select ClientId from Client where Email = 'lay@gmail.com'))
                                   insert into Project(Name, Budget, StartedDate, ClientId) values('Test project 5', 50, '2020-08-21', (select ClientId from Client where Email = 'lay@gmail.com'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Client_ClientId",
                table: "Project");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Project_ClientId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Project");

            migrationBuilder.Sql("delete from Project where Name in ('Test project 1', 'Test project 2', 'Test project 3', 'Test project 4', 'Test project 5')");
        }
    }
}
