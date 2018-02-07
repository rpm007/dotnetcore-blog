using System;
using System.Collections.Generic;
using System.Text;
using Core.Domain;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<Post> GetPostWithTags(int id);
        Task<Post> GetDisplay(int id);
    }
}
