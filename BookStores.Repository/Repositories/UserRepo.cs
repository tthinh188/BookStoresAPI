using BookStores.Domain.Models;
using BookStores.Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStores.Repository.Repositories
{
    public class UserRepo : Repository<User>, IUserRepo
    {
        public UserRepo(BookStoreDBContext context) : base(context) { }
        public Task<User> AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
