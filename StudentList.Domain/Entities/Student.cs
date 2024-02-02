using StudentList.Domain.Commons;
using StudentList.Domain.Enums;

namespace StudentList.Domain.Entities
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Teacher { get; set; }
        public DateTime Date { get; set; }
        public double Contract { get; set; }
        public StudentStatus Status { get; set; }
    }
}
