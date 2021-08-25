using BookStores.Domain.Models;
using BookStores.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStores.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork uow;

        public UserService(IUnitOfWork Uow)
        {
            uow = Uow;
        }
        public Task<User> CreateUser(User author)
        {

            throw new NotImplementedException();
        }

        public Task<User> GetUserById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
