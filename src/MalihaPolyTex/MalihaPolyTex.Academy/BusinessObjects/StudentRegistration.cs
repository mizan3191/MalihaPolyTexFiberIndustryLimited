using System;

namespace MalihaPolyTex.Academy.BusinessObjects
{
    public class StudentRegistration
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollDate { get; set; }
        public bool IsPaymentComplete { get; set; }

    }
}