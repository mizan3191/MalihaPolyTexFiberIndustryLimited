using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MalihaPolyTex.Web.Models.Demo
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        [NotMapped]
        public int ProductID { get; set; }
        [NotMapped]
        public int SubCategoryID { get; set; }
    }
}
