using System;
using System.Collections.Generic;
using System.Text;
using Core.Domain;
using Core.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Markdig;

namespace Data.Repositories
{
    [Authorize]
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public DataContext DataContext
        {
            get { return Context as DataContext; }
        }

        public PostRepository(DataContext context) : base(context)
        {
            
        }

        public async Task<Post> GetPostWithTags(int id)
        {
            return await DataContext.Posts.Include(p => p.Tags).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Post> GetDisplay(int id)
        {
            var post = await DataContext.Posts.Include(p => p.Tags).SingleOrDefaultAsync(p => p.Id == id);

            if (!string.IsNullOrEmpty(post.Content))
                post.Content = Markdown.ToHtml(post.Content);

            return post;
        }
    }
}