using System;

namespace MalihaPolyTex.Institute.BusinessObjects
{
    public class Student
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}