namespace solfagito_learn.Models.Products
{
    public class CategoryViewModel
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public string? search { get; set; }
        public int totalItems { get; set; }
        public IEnumerable<Categorys> Category { get; set; }
    }
}
