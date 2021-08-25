using BookStores.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStores.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAuthors();
        Task<Author> GetAuthorById(int Id);
        Task<Author> CreateAuthor(Author author);
        Task DeleteAuthor(Author author);
        Task UpdateAuthor(Author AuthorToUpdate, Author author);
    }
}
