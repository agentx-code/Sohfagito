using solfagito_learn.Models.Users;
using solfagito_learn.Repository.Interface;
using solfagito_learn.Services.Interface;

namespace solfagito_learn.Services.Implementation
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository )
        {
            _userRepository = userRepository;
        }
        public async Task<UsersViewModel> User(int? page = 1, int? pageSize = 5, string? search = null)
        {
            return await _userRepository.User(page, pageSize, search);
        }
    }
}
