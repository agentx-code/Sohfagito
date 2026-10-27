using System.ComponentModel.DataAnnotations.Schema;

namespace solfagito_learn.Models.Products
{
    [Table("tbl_categories")]
    public class Categorys
    {
        public Guid id { get; set; }
        public string? category_name { get; set; }
        public Guid? parent_id { get; set; }
        public string? description { get; set; }
        public string? image { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }
        public string? public_id { get; set; }
    }
}
