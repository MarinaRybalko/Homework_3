using Microsoft.EntityFrameworkCore.Migrations;

namespace Module4task3.Migrations
{
    public partial class InsertData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"SET IDENTITY_INSERT Office ON
                                   insert into Office(OfficeId, Title, Location) values(1, 'Premium', 'Kharkiv')
                                   SET IDENTITY_INSERT Office OFF");

            migrationBuilder.Sql(@"SET IDENTITY_INSERT Title ON
                                   insert into Title(TitleId, Name) values(1, 'Php dev')
                                   insert into Title(TitleId, Name) values(2, 'Python dev')
                                   insert into Title(TitleId, Name) values(3, 'QA')
                                   insert into Title(TitleId, Name) values(4, 'Designer')
                                   SET IDENTITY_INSERT Title OFF");

            migrationBuilder.Sql(@"SET IDENTITY_INSERT Employee ON
                                   insert into Employee(EmployeeId, FirstName, LastName, HiredDate, BirthDate, TitleId, OfficeId) values(1, 'Hie', 'Mwer', '2021-01-12', '1998-01-02', 1, 1)
                                   insert into Employee(EmployeeId, FirstName, LastName, HiredDate, BirthDate, TitleId, OfficeId) values(2, 'Key', 'Huu', '2021-01-02', '1996-06-06', 2, 1)
                                   insert into Employee(EmployeeId, FirstName, LastName, HiredDate, BirthDate, TitleId, OfficeId) values(3, 'Zie', 'Meen', '2020-11-02', '1991-11-22', 2, 1)
                                   insert into Employee(EmployeeId, FirstName, LastName, HiredDate, BirthDate, TitleId, OfficeId) values(4, 'Loa', 'Kiuu', '2021-03-02', '1999-08-12', 1, 1)
                                   SET IDENTITY_INSERT Employee OFF");

            migrationBuilder.Sql(@"SET IDENTITY_INSERT EmployeeProject ON
                                   insert into EmployeeProject(EmployeeProjectId, EmployeeId, ProjectId, Rate, StartedDate) values(1, 1, (select ProjectId from Project where Name = 'Test project 1'), 100, '2021-03-12')
                                   insert into EmployeeProject(EmployeeProjectId, EmployeeId, ProjectId, Rate, StartedDate) values(2, 2, (select ProjectId from Project where Name = 'Test project 2'), 200, '2021-04-10')
                                   insert into EmployeeProject(EmployeeProjectId, EmployeeId, ProjectId, Rate, StartedDate) values(3, 2, (select ProjectId from Project where Name = 'Test project 2'), 200, '2021-04-10')
                                   insert into EmployeeProject(EmployeeProjectId, EmployeeId, ProjectId, Rate, StartedDate) values(4, 1, (select ProjectId from Project where Name = 'Test project 1'), 100, '2021-03-12')
                                   SET IDENTITY_INSERT EmployeeProject OFF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Office where OfficeId in (1)");
            migrationBuilder.Sql("delete from Title where TitleId in (1, 2, 3, 4)");
            migrationBuilder.Sql("delete from Employee where EmployeeId in (1, 2, 3, 4)");
            migrationBuilder.Sql("delete from EmployeeProject where EmployeeProjectId in (1, 2, 3, 4)");
        }
    }
}
