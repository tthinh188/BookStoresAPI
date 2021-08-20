using BookStores.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStores.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorRepo Authors { get; }
        Task<int> CommitAsync();

    }
}
