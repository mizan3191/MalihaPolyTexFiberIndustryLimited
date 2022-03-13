using System.ComponentModel.DataAnnotations;

namespace MalihaPolyTex.Web.Models.Demo
{
    public class MainProduct
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SubCategoryID { get; set; }
    }
}
