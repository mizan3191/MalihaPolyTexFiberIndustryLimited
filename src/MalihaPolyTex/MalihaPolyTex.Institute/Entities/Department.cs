using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalihaPolyTex.Institute.Entities
{
    public class Department : IEntity<int>
    {
        public int Id { get; set; }
        public string DeptName { get; set; }
    }
}
