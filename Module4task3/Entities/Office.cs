using System.Collections.Generic;

namespace Module4task3.Entities
{
    public class Office
    {
        public int OfficeId { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }

        public virtual List<Employee> Employee { get; set; } = new List<Employee>();
    }
}
