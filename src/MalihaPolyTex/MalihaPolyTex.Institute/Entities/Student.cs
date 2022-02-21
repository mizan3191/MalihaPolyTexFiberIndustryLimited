using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalihaPolyTex.Institute.Entities
{
    public class Student : IEntity<int>
    {
        public int Id { get; set; }
        public int DeptId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
