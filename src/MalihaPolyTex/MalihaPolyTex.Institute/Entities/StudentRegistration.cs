using DevSkill.Data;

namespace MalihaPolyTex.Institute.Entities
{
    public class StudentRegistration : IEntity<int>
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int EnrollDate { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
        public bool IsPaymentComplete { get; set; }
    }
}