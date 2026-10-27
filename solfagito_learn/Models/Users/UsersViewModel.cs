namespace solfagito_learn.Models.Users
{
    public class UsersViewModel
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public string? search { get; set; }
        public int totalUsers { get; set; }
        public IEnumerable<Users> User { get; set; }
    }
}
