using DevSkill.Data;
using System.Collections.Generic;

namespace MalihaPolyTex.Institute.Entities
{
    public class Department : IEntity<int>
    {
        public int Id { get; set; }
        public string DeptName { get; set; }
        public List<Student> Students { get; set; }
    }
}