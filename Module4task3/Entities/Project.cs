using System;
using System.Collections.Generic;

namespace Module4task3.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartedDate { get; set; }

        public List<EmployeeProject> EmployeeProject { get; set; } = new List<EmployeeProject>();
    }
}
