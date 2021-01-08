using Application.DTO.Request;
using Application.Interfaces;
using Domain;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Application.Blog.Services
{
    public class CommentService : ICommentService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IHttpContextAccessor _accessor;
        
        public CommentService(IPostRepository postRepository, IUserRepository userRepository, ICommentRepository commentRepository, IHttpContextAccessor accessor)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            _commentRepository = commentRepository;
            _accessor = accessor;
        }

        public async Task<Guid> Create(CommentDTO commentDTO)
        {
            var login = _accessor.HttpContext.User.Identity.Name;
            var user = await _userRepository.GetByUsername(login);
            var post = await _postRepository.GetById(commentDTO.PostId);

            if (user == null)
                throw new Exception("Usuário não encontrado.");

            if (post == null)
                throw new Exception("Post não encontrado.");

            var comment = new Comment(commentDTO.Text, user, post);

            await _commentRepository.AddAsync(comment);

            return comment.Id;
        }

        public async Task Delete(Guid id)
        {
            var login = _accessor.HttpContext.User.Identity.Name;
            var user = await _userRepository.GetByUsername(login);

            var comment = await _commentRepository.GetById(id);

            if (comment == null)
                throw new Exception("Não foi possível localizar este comentário!");

            if (comment.UserId != user.Id)
                throw new Exception("Você não tem permissão para excluir este comentário!");

            await _commentRepository.RemoveAsync(comment);
        }
        public Task<Comment> GetById(Guid id)
        {
            var comment = _commentRepository.GetById(id);

            if (comment.Result == null)
                throw new Exception("Comentário não encontrado!");

            return comment;
        }
    }
}
