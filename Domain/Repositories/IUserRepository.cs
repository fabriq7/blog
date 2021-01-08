using Shared.Entities.Interfaces;
using System;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetById(Guid id);
        Task<User> GetByUsername(string username);
    }
}
