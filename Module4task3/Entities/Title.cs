using System.Collections.Generic;

namespace Module4task3.Entities
{
    public class Title
    {
        public int TitleId { get; set; }
        public string Name { get; set; }

        public virtual List<Employee> Employee { get; set; } = new List<Employee>();
    }
}
