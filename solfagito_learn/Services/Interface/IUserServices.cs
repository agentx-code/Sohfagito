using solfagito_learn.Models.Users;

namespace solfagito_learn.Services.Interface
{
    public interface IUserServices
    {
        Task<UsersViewModel> User(int? page = 1, int? pageSize = 5, string? search = null);
    }
}
