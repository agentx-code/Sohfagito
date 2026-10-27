using solfagito_learn.Models.Users;

namespace solfagito_learn.Repository.Interface
{
    public interface ILoginRepository
    {
        Task<Users?> Login(string Email, string Password);
    }
}
