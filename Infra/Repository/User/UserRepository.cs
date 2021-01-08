using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Domain;
using Infra.Repository.Base;
using Domain.Repositories;
using Infra.Context;

namespace Blog.Infra.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private new readonly AppDbContext _context;

        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetById(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetByUsername(string login)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Login == login.ToLower());
        }
    }
}
