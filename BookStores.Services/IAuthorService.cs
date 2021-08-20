using BookStores.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStores.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAuthors();
        Task<Author> GetAuthorById(int Id);
        Task UpdateAuthor(Author AuthorToUpdate, Author author);
    }
}
