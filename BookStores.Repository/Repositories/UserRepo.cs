using BookStores.Domain.Models;
using BookStores.Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookStores.Repository.Repositories
{
    public class UserRepo : Repository<User>, IUserRepo
    {
        public UserRepo(BookStoreDBContext context) : base(context) { }

        public async Task<User> GetUserAsync(User user)
        {
            return await BookStoreDBContext.Users
                                            .SingleOrDefaultAsync(u => u.EmailAddress == user.EmailAddress && u.Password == user.Password);
        }
        private BookStoreDBContext BookStoreDBContext
        {
            get { return Context as BookStoreDBContext; }
        }
    }
}
