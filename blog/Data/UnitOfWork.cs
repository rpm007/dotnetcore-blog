using System;
using System.Collections.Generic;
using System.Text;
using Core;
using Core.Repositories;
using Data.Repositories;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Posts = new PostRepository(_context);
        }

        public IPostRepository Posts { get; private set; }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
