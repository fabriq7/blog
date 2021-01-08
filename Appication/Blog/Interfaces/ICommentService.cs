using Application.DTO.Request;
using Domain;
using System;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICommentService
    {
        Task<Guid> Create(CommentDTO postDTO);
        Task<Comment> GetById(Guid id);
        Task Delete(Guid Id);        
    }
}
