using BookStores.Domain.Models;
using BookStores.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStores.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork uow;

        public AuthorService(IUnitOfWork Uow)
        {
            uow = Uow;
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await uow.Authors.GetAllAuthors();
        }

        public async Task<Author> GetAuthorById(int Id)
        {
            return await uow.Authors.GetAuthorByIdAsync(Id);
        }

        public async Task UpdateAuthor(Author AuthorToBeUpdated, Author author)
        {
            AuthorToBeUpdated.Address = author.Address;
            AuthorToBeUpdated.City = author.City;
            AuthorToBeUpdated.EmailAddress = author.EmailAddress;
            AuthorToBeUpdated.FirstName = author.FirstName;
            AuthorToBeUpdated.LastName = author.LastName;
            AuthorToBeUpdated.Phone = author.Phone;
            AuthorToBeUpdated.State = author.State;
            AuthorToBeUpdated.Zip = author.Zip;

            await uow.CommitAsync();
        }
    }
}
