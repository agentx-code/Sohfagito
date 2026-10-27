using solfagito_learn.Models.Users;

namespace solfagito_learn.Repository.Interface
{
    public interface IUserRepository
    {
        Task<UsersViewModel> User(int? page = 1, int? pageSize = 5, string? search = null);
    }
}
