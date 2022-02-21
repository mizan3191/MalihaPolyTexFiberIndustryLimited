namespace MalihaPolyTex.Institute.BusinessObjects
{
    public class StudentRegistration
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int EnrollDate { get; set; }
        public bool IsPaymentComplete { get; set; }
    }
}
