using solfagito_learn.Models.Users;

namespace solfagito_learn.Services.Interface
{
    public interface ILoginServices
    {
        Task<(Users? user, bool sucess, string message)> LoginAsync(string email, string password);
    }
}
