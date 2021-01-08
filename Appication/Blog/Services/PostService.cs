using Application.DTO.Request;
using Application.Interfaces;
using Blog.Infra.Data.Repository;
using Domain;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Infra.Services;

namespace Application.Blog.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _accessor;
        //
        public PostService(IPostRepository postRepository, IUserRepository userRepository, IHttpContextAccessor accessor)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            _accessor = accessor;
        }

        public async Task<Guid> Create(PostDTO postDTO)
        {
            var login = _accessor.HttpContext.User.Identity.Name;
            var user = await _userRepository.GetByUsername(login);

            if (user == null)
                throw new Exception("Usuário não encontrado.");

            var post = new Post(postDTO.Text, postDTO.Image, postDTO.Link, user);

            await _postRepository.AddAsync(post);

            return post.Id;
        }

        public async Task Delete(Guid id)
        {
            var login = _accessor.HttpContext.User.Identity.Name;
            var user = await _userRepository.GetByUsername(login);

            var post = await _postRepository.GetById(id);

            if (post == null)
                throw new Exception("Não foi possível localizar este post!");

            if (post.UserId != user.Id)
                throw new Exception("Você não tem permissão para excluir este post!");

            await _postRepository.RemoveAsync(post);
        }

        public Task<Post> GetByImage(string image)
        {
            var post = _postRepository.GetByImage(image);

            if (post.Result == null)
                throw new Exception("Post não encontrado!");

            return post;
        }

        public Task<Post> GetByLink(string link)
        {
            var post = _postRepository.GetByLink(link);

            if (post.Result == null)
                throw new Exception("Post não encontrado!");

            return post;
        }

        public Task<Post> GetByText(string text)
        {
            var post = _postRepository.GetByText(text);

            if (post.Result == null)
                throw new Exception("Post não encontrado!");

            return post;
        }
    }
}
