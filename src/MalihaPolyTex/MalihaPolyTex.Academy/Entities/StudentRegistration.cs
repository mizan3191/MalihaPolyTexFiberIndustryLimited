using DevSkill.Data;
using System;

namespace MalihaPolyTex.Academy.Entities
{
    public class StudentRegistration
    {
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollDate { get; set; }
        public bool IsPaymentComplete { get; set; }
    }
}