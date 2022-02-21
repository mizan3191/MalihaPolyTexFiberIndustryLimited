using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalihaPolyTex.Institute.Entities
{
    public class StudentRegistration : IEntity<int>
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int EnrollDate { get; set; }
        public bool IsPaymentComplete { get; set; }
    }
}
