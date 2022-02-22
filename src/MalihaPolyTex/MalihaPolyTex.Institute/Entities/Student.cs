using DevSkill.Data;
using System;
using System.Collections.Generic;

namespace MalihaPolyTex.Institute.Entities
{
    public class Student : IEntity<int>
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Department Department { get; set; } 
        public List<StudentRegistration> EnrolledCourses { get; set; }

    }
}