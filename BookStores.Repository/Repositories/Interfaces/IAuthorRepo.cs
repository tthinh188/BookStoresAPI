using BookStores.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStores.Repository.Repositories.Interfaces
{
    public interface IAuthorRepo : IRepository<Author>
    {
        Task<IEnumerable<Author>> GetAllAuthors();
        Task<Author> GetAuthorByIdAsync(int Id);
    }
}
