using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Domain;
using Infra.Repository.Base;
using Domain.Repositories;
using Infra.Context;

namespace Blog.Infra.Data.Repository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private new readonly AppDbContext _context;

        public CommentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Comment> GetById(Guid id)
        {
            return await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
