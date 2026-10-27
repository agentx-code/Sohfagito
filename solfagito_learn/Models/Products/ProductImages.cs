using System.ComponentModel.DataAnnotations.Schema;

namespace solfagito_learn.Models.Products
{
    public class ProductImages
    {
        public Guid id { get; set; }
        public Guid product_id { get; set; }
        public string? image { get; set; }
        public bool is_primary { get; set; }
        public int sort_order { get; set; }
        public DateTime created_at { get; set; }
        public string? public_id { get; set; }

        [ForeignKey(nameof(product_id))]
        public Products product { get; set; }
    }
}
