using BookStores.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookStores.Repository.Repositories
{
    public class AuthorRepo : Repository<Author>, IAuthorRepo
    {
        public AuthorRepo(BookStoreDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await  BookStoreDBContext.Authors
                                            .Include(a => a.BookAuthors)
                                            .ToListAsync();
        }

        public async Task<Author> GetAuthorByIdAsync(int Id)
        {
            return await BookStoreDBContext.Authors
                                            .Include(a => a.BookAuthors)
                                            .SingleOrDefaultAsync(a => a.AuthorId == Id);
        }

        private BookStoreDBContext BookStoreDBContext
        {
            get { return Context as BookStoreDBContext; }
        }
    }
}
