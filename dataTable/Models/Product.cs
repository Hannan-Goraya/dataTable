using dataTable.data;
using System.ComponentModel.DataAnnotations.Schema;

namespace dataTable.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price{ get; set; }
        public int catId { get; set; }


        
        public IFormFile ImgUpload { get; set; }
    }


    public class Category
    {
        public int Id { get; set; }
        public string CatName { get; set; }
    }


}
