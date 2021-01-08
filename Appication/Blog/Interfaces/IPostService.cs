using Application.DTO.Request;
using Domain;
using System;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPostService
    {
        Task<Guid> Create(PostDTO postDTO);
        Task Delete(Guid Id);
        Task<Post> GetById(Guid id);
        Task<Post> GetByText(string text);
        Task<Post> GetByImage(string image);
        Task<Post> GetByLink(string link);
    }
}
