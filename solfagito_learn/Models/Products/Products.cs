using System.ComponentModel.DataAnnotations.Schema;

namespace solfagito_learn.Models.Products
{
    [Table("tbl_products")]
    public class Products
    {
        public Guid id { get; set; }
        public Guid category_id { get; set; }
        public string? product_name { get; set; }
        public string? description { get; set; }
        public string? bottle_size_ml { get; set; }
        public decimal price { get; set; }
        public decimal discount_price { get; set; }
        public int stock { get; set; }
        public string? sku { get; set; }
        public bool is_featured { get; set; }
        public string? status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }



        public ICollection<ProductImages> Images { get; set; }

        [ForeignKey(nameof(category_id))]
        public Categorys category { get; set; }
    }
}
