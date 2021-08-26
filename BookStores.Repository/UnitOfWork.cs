using BookStores.Domain.Models;
using BookStores.Repository.Repositories;
using BookStores.Repository.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace BookStores.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookStoreDBContext Context;
        private AuthorRepo _authorRepo;
        private UserRepo _userRepo;

        public UnitOfWork(BookStoreDBContext context)
        {
            this.Context = context;
        }

        public IAuthorRepo Authors => _authorRepo = _authorRepo ?? new AuthorRepo(Context);
        public IUserRepo Users => _userRepo = _userRepo ?? new UserRepo(Context);

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
