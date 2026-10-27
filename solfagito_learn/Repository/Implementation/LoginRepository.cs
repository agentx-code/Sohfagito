using Microsoft.EntityFrameworkCore;
using solfagito_learn.Data;
using solfagito_learn.Models.Users;
using solfagito_learn.Repository.Interface;

namespace solfagito_learn.Repository.Implementation
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AppDbContext _context;
        public LoginRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Users? > Login(string Email, string Password)
        {
            var user  = await _context.User.Include(r => r.Role).FirstOrDefaultAsync(u  => u.Email == Email && u.Password == Password);
            return user;
        }
    }
}
