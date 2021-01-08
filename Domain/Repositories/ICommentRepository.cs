using Shared.Entities.Interfaces;
using System;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<Comment> GetById(Guid id);
    }
}
