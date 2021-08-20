using BookStores.Domain.Models;
using BookStores.Repository.Repositories;
using System;
using System.Threading.Tasks;

namespace BookStores.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookStoreDBContext Context;
        private AuthorRepo _authorRepo;

        public UnitOfWork(BookStoreDBContext context)
        {
            this.Context = context;
        }

        public IAuthorRepo Authors => _authorRepo = _authorRepo ?? new AuthorRepo(Context);

        public async Task<int> CommitAsync()
        {
            return await Context.SaveChangesAsync();
        }
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
