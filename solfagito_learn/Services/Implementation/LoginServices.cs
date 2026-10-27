using solfagito_learn.Models.Users;
using solfagito_learn.Repository.Interface;
using solfagito_learn.Services.Interface;

namespace solfagito_learn.Services.Implementation
{
    public class LoginServices : ILoginServices
    {
        private readonly ILoginRepository _loginRepository;
        public LoginServices(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public async Task<(Users? user, bool sucess, string message)> LoginAsync(string Email, string Password)
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password)) 
            {
                return (null, false, "Authentication Failed");
            }

            var user = await _loginRepository.Login(Email, Password);

            if (user == null)
            {
                return (null, false, "Invalid Email or Password");
            }
            return (user, true, "Authentication Sucess");
        }
    }
}
