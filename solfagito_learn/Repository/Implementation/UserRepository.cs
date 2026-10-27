using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using solfagito_learn.Data;
using solfagito_learn.Models.Users;
using solfagito_learn.Repository.Interface;

namespace solfagito_learn.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<UsersViewModel> User(int? page = 1, int? pageSize = 5,string? Search = null)
        {
            try
            {

                var query = _context.User.Include(r => r.Role).AsQueryable();

                if (!string.IsNullOrEmpty(Search))
                {
                    query = query.Where(u => u.Name.Contains(Search) || u.Email.Contains(Search));
                }

                int totalUsers = await query.CountAsync();

                if (page.HasValue && pageSize.HasValue)
                {
                    query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
                }
                var User = await query.ToListAsync();
                return new UsersViewModel
                {
                    page = page ?? 1,
                    pageSize = pageSize ?? 10,
                    totalUsers = totalUsers,
                    User = User
                };
            }
            catch(Exception ex)
            {
                throw;
            }
            
        }
    }
}
