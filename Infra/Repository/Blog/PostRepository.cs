using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Domain;
using Infra.Repository.Base;
using Domain.Repositories;
using Infra.Context;

namespace Blog.Infra.Data.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        private new readonly AppDbContext _context;

        public PostRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Post> GetById(Guid id)
        {
            return await _context.Posts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Post> GetByImage(string image)
        {
            return await _context.Posts.FirstOrDefaultAsync(x => x.Image == image);
        }

        public async Task<Post> GetByLink(string link)
        {
            return await _context.Posts.FirstOrDefaultAsync(x => x.Link == link);
        }

        public async Task<Post> GetByText(string text)
        {
            return await _context.Posts.FirstOrDefaultAsync(x => x.Text == text);
        }
    }
}
