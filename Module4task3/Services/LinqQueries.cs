using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Module4task3.Entities;

namespace Module4task3.Services
{
    public class LinqQueries
    {
        private readonly ApplicationContext _context;

        public LinqQueries(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Task1()
        {
            Console.WriteLine("-----------Задание 1------------------");

            var data = await (from title in _context.Titles
                join employee in _context.Employees
                    on title.TitleId equals employee.TitleId into employees
                from employeeTitle in employees.DefaultIfEmpty()
                join employeeProject in _context.EmployeeProjects
                    on employeeTitle.EmployeeId equals employeeProject.EmployeeId into employeeTitleProject
                from result in employeeTitleProject.DefaultIfEmpty()
                select new
                    {
                        EmployeeName = employeeTitle.FirstName + " " + employeeTitle.LastName,
                        TitleName = title.Name
                    }).ToListAsync();

            foreach (var employee in data)
                Console.WriteLine($"Employee Name: {employee.EmployeeName}. Title Name: {employee.TitleName}.");
        }

        public async Task Task2()
        {
            Console.WriteLine("-----------Задание 2------------------");
            var result = await _context.Employees.Select(s => new
                {
                    EmployeeName = $"{s.FirstName} {s.LastName}",
                    Age = EF.Functions.DateDiffDay(s.BirthDate, DateTime.Today)
                })
                .ToListAsync();

            foreach (var employee in result)
                Console.WriteLine($"Name: {employee.EmployeeName}. Age: {employee.Age}.");
        }

        public async Task Task3()
        {
            Console.WriteLine("-----------Задание 3------------------");
            var employee = await _context.Employees.FirstAsync(x => x.EmployeeId == 1);
            var title = await _context.Titles.FirstAsync(x => x.TitleId == 1);
            Console.WriteLine($"Current Title: {title.Name}. Current First Name: {employee.FirstName}");

            employee.FirstName = "Updated First Name";
            title.Name = "Updated Title";
            await _context.SaveChangesAsync();

            var updatedEmployee = await _context.Employees.FirstAsync(x => x.EmployeeId == 1);
            var updatedTitle = await _context.Titles.FirstAsync(x => x.TitleId == 1);
            Console.WriteLine($"Updated Title: {updatedTitle.Name}. Updated First Name: {updatedEmployee.FirstName}");
        }

        public async Task Task4()
        {
            Console.WriteLine("-----------Задание 4------------------");
            var office = await _context.Offices.FirstAsync(w => w.OfficeId == 1);
            var project = await _context.Projects.FirstAsync(w => w.ProjectId == 1);
            var title = await _context.Titles.FirstAsync(w => w.TitleId == 1);

            var employee = new Employee
            {
                FirstName = "Mary",
                LastName = "Jog",
                BirthDate = new DateTime(1999, 10, 13),
                HiredDate = new DateTime(2020, 3, 10),
                OfficeId = office.OfficeId,
                TitleId = title.TitleId,
                EmployeeProject = new List<EmployeeProject>() { new EmployeeProject() { Rate = 100, ProjectId = project.ProjectId, StartedDate = new DateTime(2020, 3, 10) } }
            };

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task Task5()
        {
            Console.WriteLine("-----------Задание 5------------------");
            var employee = await _context.Employees.LastAsync(x => x.EmployeeId == 2);

            _context.EmployeeProjects.RemoveRange(employee.EmployeeProject);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task Task6()
        {
            Console.WriteLine("-----------Задание 6------------------");
            var titles = await _context.Employees
                .Where(w => !w.Title.Name.Contains("a"))
                .GroupBy(g => g.Title.Name)
                .Select(x => x.Key)
                .ToListAsync();

            foreach (var title in titles)
                Console.WriteLine($"Title: {title}");
        }
    }
}
