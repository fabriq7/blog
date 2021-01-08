using Shared.Entities.Interfaces;
using System;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<Post> GetById(Guid id);
        Task<Post> GetByText(string text);
        Task<Post> GetByImage(string image);
        Task<Post> GetByLink(string link);
    }
}
