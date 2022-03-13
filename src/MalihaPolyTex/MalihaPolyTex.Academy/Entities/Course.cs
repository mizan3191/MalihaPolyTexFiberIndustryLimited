using DevSkill.Data;
using System.Collections.Generic;

namespace MalihaPolyTex.Academy.Entities
{
    public class Course : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int SeatCount { get; set; }
        public int Fee { get; set; }
        public List<StudentRegistration> EnrollStudents { get; set; }
    }
}